﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingItem : MonoBehaviour {
    public int healAmount = -15;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<hopefullyhealthbar>().TakeDamage(healAmount);
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyHealth>().updateHealth(healAmount);
            Destroy(this.gameObject);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
