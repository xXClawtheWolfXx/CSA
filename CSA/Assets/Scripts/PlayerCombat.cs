using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour {

    //config params
    [Header("Objs")]
    [SerializeField] Sprite[] combatSprites;
    [SerializeField] GameObject sprayParticles;
    
    [Header("Floats")]
    [SerializeField] float sprayParticlesSpeed = 10f;
    [SerializeField] float firingPeriod = .1f;
    [SerializeField] float playerHitPoints; 

    [Header("Health")]
    [SerializeField] int playerHealth = 100;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject healthPickup;
    [SerializeField] int healthPickupIncrease = 20;

    Vector3 sprayPosOffset = new Vector3(1, 0, 0);
    Vector3 moveBackPos = new Vector3(-1, 0, 0);

    Coroutine combatCoroutine;

    Sprite currSprite;

    //cached refs
    SpriteRenderer spriteRenderer;
    Enemy enemy;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = FindObjectOfType<Enemy>();

        currSprite = spriteRenderer.sprite;

        playerHitPoints = sprayParticlesSpeed / 2;

        healthText.text = playerHealth.ToString();
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           combatCoroutine = StartCoroutine(Combat());
            
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopCoroutine(combatCoroutine);
            spriteRenderer.sprite = currSprite;
        }

    }

    IEnumerator Combat()
    {
        while (true)
        {
            spriteRenderer.sprite = combatSprites[0];
            GameObject sp = Instantiate(sprayParticles, 
                transform.position + sprayPosOffset,
                Quaternion.identity) as GameObject;

            sp.GetComponent<Rigidbody2D>().velocity = 
                new Vector2(sprayParticlesSpeed, 0f);

            yield return new WaitForSeconds(firingPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemy.gameObject)
        {
            transform.position -= moveBackPos;
            playerHealth -= enemy.GetEnemyHitPoints();
            healthText.text = playerHealth.ToString();
        }
        else if (collision.gameObject == healthPickup.gameObject)
        {
            playerHealth += healthPickupIncrease;
            healthText.text = playerHealth.ToString();
        }
    }

    

    public float GetPlayerHitPoints()
    {
        return playerHitPoints;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
