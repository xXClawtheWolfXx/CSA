﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRidOfSpray : MonoBehaviour {

    [SerializeField] private GameObject spray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "spray")
        Destroy(collision.gameObject);
        
    }
}
