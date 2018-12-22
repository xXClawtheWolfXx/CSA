using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] int hitPoints = 20;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float health = 100f;
    [SerializeField] Image fillBar;
    [SerializeField] GameObject enemyProj;


    [SerializeField] float enemyProjSpeed = 5f;
    [SerializeField] float firingPeriod = .1f;
    [SerializeField] float secondsBetweenDestroy = .2f;

    Vector2 targetPos;
    Vector2 currentPos;
    Vector3 sprayPosOffset = new Vector3(1.05f, 0, 0);

    

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
        if (collision.gameObject == player)
        {
            Debug.Log("fshdfjkdfhsjkdfkskjsfddkkfkjssdfj");
            DecreasePlayerHealth(collision.gameObject);
        }
        else
        {

            DecreaseOwnHealth(collision.gameObject);
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

    private void DecreaseOwnHealth(GameObject collision)
    {

        Destroy(collision);
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


        StartCoroutine(EnemyCombat());
       
        transform.position = Vector2.MoveTowards(currentPos, targetPos, maxDist);
    }

    IEnumerator EnemyCombat()
    {
        while (true)
        {

            GameObject ep = Instantiate(enemyProj,
                transform.position - sprayPosOffset,
                Quaternion.identity) as GameObject;

            ep.GetComponent<Rigidbody2D>().velocity =
                new Vector2(-enemyProjSpeed, 0f);

            yield return new WaitForSeconds(firingPeriod);
            StartCoroutine(ParticleDestroyer(ep));


        }
    }


    IEnumerator ParticleDestroyer(GameObject ep)
    {

        yield return new WaitForSeconds(secondsBetweenDestroy);
        Destroy(ep);
    }

}
