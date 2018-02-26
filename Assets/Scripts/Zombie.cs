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

	public override void scaleBiome(float mod1, float mod2, Color colorchange) // May need to be a Color instead of a Vector 4
    {
        healthTracker = GetComponent<EnemyHealth>();
        healthTracker.setHealth(BaseHealth*mod1);
        GetComponent<SpriteRenderer>().color = colorchange;
        Movespeed = Movespeed * mod2;
        return;
    }

	void OnCollisionEnter2D(Collision2D collider)
    {
        //print("I am the attacking");
        if(collider.gameObject.tag == "Player")
            Player.GetComponent<hopefullyhealthbar>().TakeDamage(AttackDamage);
    }
}
