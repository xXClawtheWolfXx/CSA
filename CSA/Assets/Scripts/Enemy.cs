using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField] int hitPoints = 20;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float health = 100f;
    [SerializeField] Image fillBar;
    [SerializeField] GameObject sprayParticles;
    

    Vector2 targetPos;
    Vector2 currentPos;


    PlayerCombat player;


    private void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        Debug.Log(player);
        //  sprayParticles = CompareTag("spray");
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == sprayParticles)
        {
            DecreaseOwnHealth(collision);
        }
        else
        {
            DecreasePlayerHealth(collision.gameObject);
        }
        //DecreasePlayerHealth(collision.gameObject);
        //DecreasePlayerHealth(collision.gameObject);
        Debug.Log(collision.name);

    }

    private void DecreasePlayerHealth(GameObject collision)
    {
        int playerhealth = player.GetPlayerHealth();
        playerhealth -= hitPoints;
       // player.
    }

    private void DecreaseOwnHealth(Collider2D collision)
    {

        Destroy(collision.gameObject);
        health -= player.GetPlayerHitPoints();

        fillBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetEnemyHitPoints()
    {
        return hitPoints;
    }

    public void MoveToPlayer()
    {
        currentPos = transform.position;
        targetPos = player.transform.position;
        float maxDist = moveSpeed * Time.deltaTime;

       

        transform.position = Vector2.MoveTowards(currentPos, targetPos, maxDist);
    }
}
