using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : BaseEnemy {

	public int chargespeed = 25;
	public int chargedamage = 15;
	public float waittime = .5f;
	public int chargeduration = 1;
	public int cooldown = 1;
	private Vector3 movement;
	private Vector3 oldpos;
	private bool charging = false;
	public float chargemod;      // Set by Biome in Monster Spawn and used to increase move speed during charge and decrease wait time on charge
	public float waitmod; 		 // 0 < chargemod < 2     0 < waitmod < 2
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
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		face();
		if(!charging)
		{
			move();
			Attack();
		}
	}

	protected override void Attack() //Shoots if in range or starts the move function
	{
		if (InRange || charging)
		{
			if(!charging)
			{
				charging = true;
				rig.velocity = new Vector3 (0,0,0);
				oldpos = Player.transform.position-transform.position;         // FINDS AND STORES PLAYER'S LOCATION
				Movespeed += chargespeed;  // CHANGE SPEED TO SILLY HIGH VALUE
				StartCoroutine(wait (waittime)); // WAIT ABOUT HALF A SECOND
												  // MOVES TOWARD INITIAL PLAYER POSITION WITH NOW MODIFIED MOVESPEED
				StartCoroutine(duration (chargeduration)); 
			}// CHARGES FOR A SET TIME
		}
	}

	IEnumerator buffer(int time)
	{
		yield return new WaitForSeconds(time);
	}

	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
		AttackDamage += chargedamage;
		rig.velocity = oldpos.normalized * Movespeed;
	}

	IEnumerator duration(int time)
	{
		yield return new WaitForSeconds(time);
		Movespeed -= chargespeed;
		AttackDamage -= chargedamage;
		rig.velocity = new Vector3 (0,0,0);
		yield return new WaitForSeconds(time);
		charging = false;
	}

	protected override void scaleBiome(string biome)
    {
        return;
    }

	public void OnCollisionEnter2D(Collision2D collider)
	{
		//print("I finally hit it!");
		if(collider.gameObject.tag == "Player")
			Player.GetComponent<hopefullyhealthbar>().TakeDamage(AttackDamage);
	}
}