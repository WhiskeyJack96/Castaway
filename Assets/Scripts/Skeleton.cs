﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy {
	public GameObject Play;
	// Use this for initialization
	void Start () {
		Player = Play;
		BaseHealth = 15f; //Zombie Base Health
        AttackDamage = 20f;
        Movespeed = 1f;
        followRange = 4f;
        scaleSizeandHealth();
        initializeValues();
        healthTracker.setHealth(BaseHealth);
		//Player = GetComponent<>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		face();
		move();
		Attack();
	}

	protected override void Attack() //Shoots if in range or starts the move function
	{
		if (InRange)
		{
			rig.velocity = new Vector3 (0,0,0);
			GetComponent<EnemyRangedAttack>().inrange(true);
		}
		else
			GetComponent<EnemyRangedAttack>().inrange(false);
	}

	public override void scaleBiome(float mod1, float mod2, Color colorchange)
    {
    	healthTracker = GetComponent<EnemyHealth>();
    	healthTracker.setHealth(BaseHealth * mod1);
    	followRange = followRange * mod2;
        GetComponent<SpriteRenderer>().color = colorchange;
        return;
    }

	public void OnCollisionEnter2D(Collision2D collider)
	{
		//print("I am the attacking");
		if(collider.gameObject.tag == "Player")
			Player.GetComponent<hopefullyhealthbar>().TakeDamage(AttackDamage);
        if(collider.gameObject.tag == "Structure")
            collider.gameObject.GetComponent<EnemyHealth>().updateHealth(AttackDamage);
	}
}
