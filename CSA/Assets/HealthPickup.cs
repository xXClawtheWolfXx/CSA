using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    [SerializeField] GameObject shari;

    PlayerCombat playerCombat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //shari.GetComponent<PlayerCombat>().UpdateHeartGUI(true);
        
    }
}
