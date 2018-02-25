using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy {
	public GameObject Play;
	// Use this for initialization
	void Start () {
		Player = Play;
        BaseHealth = 15f; //Zombie Base Health
        AttackDamage = 5f;
        Movespeed = 1f;
        followRange = 0f;
        scaleSizeandHealth();
        initializeValues();
        healthTracker.setHealth(BaseHealth);

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		move();
		face();
	}

	protected override void scaleBiome(string biome)
    {
        return;
    }

	void OnCollisionEnter2D(Collision2D collider)
    {
        //print("I am the attacking");
        if(collider.gameObject.tag == "Player")
            Player.GetComponent<hopefullyhealthbar>().TakeDamage(AttackDamage);
    }
}
