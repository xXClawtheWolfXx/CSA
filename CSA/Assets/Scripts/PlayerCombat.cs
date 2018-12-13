using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    //config params
    [SerializeField] Sprite[] combatSprites;
    [SerializeField] GameObject sprayParticles;
    [SerializeField] float sprayParticlesSpeed = 10f;
    [SerializeField] float firingPeriod = .1f;

    Vector3 sprayPosOffset = new Vector3(1, 0, 0);

    Coroutine combatCoroutine;

    Sprite currSprite;

    //cached refs
    SpriteRenderer spriteRenderer;
    Rigidbody2D sprayParticlesRB; 

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprayParticlesRB = sprayParticles.GetComponent<Rigidbody2D>();

        currSprite = spriteRenderer.sprite;

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

            sp.GetComponent<Rigidbody2D>().velocity = new Vector2(sprayParticlesSpeed, 0f);

            yield return new WaitForSeconds(firingPeriod);
        }
    }

}
