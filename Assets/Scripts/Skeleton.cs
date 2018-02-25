using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	public int damage = 20;
	public int shealth = 15;
	public float movespeed = 1f;
	private EnemyHealth health;
	public GameObject Player;
	private float playerx = 0f;
	private float playery = 0f;
	private Rigidbody2D rig;
	public float shootingdistance = 16f;
	private Vector3 movement;
	public float healthmod; //Set by Biome in Mobspawn to increase health and range
	public float rangemod;


	// Use this for initialization
	void Start () {
		rig =  GetComponent<Rigidbody2D>();
		float thealth = shealth * (Random.Range(1,2)/2f + .25f);
		health = GetComponent<EnemyHealth>();
		health.setHealth(thealth);
		//Player = GetComponent<>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		playerx = Player.transform.position.x;
		playery = Player.transform.position.y;
		movement = new Vector3 (playerx - transform.position.x,  playery - transform.position.y, 0);
		AttemptMove();
	}

	void AttemptMove() //Shoots if in range or starts the move function
	{
		if (movement.sqrMagnitude <= shootingdistance)
		{
			rig.velocity = new Vector3 (0,0,0);
			GetComponent<EnemyRangedAttack>().inrange(true);
			return;
		}
		else
			move();
			GetComponent<EnemyRangedAttack>().inrange(false);
	}


	void move() //Moves toward player
	{
		//Vector3 movement = new  Vector3(playerx - transform.position.x, playery - transform.position.y, 0).normalized * movespeed;
		rig.velocity = movement.normalized * movespeed;
		//rig.MovePosition(transform.position + movement);
	}

	public void OnCollisionEnter2D(Collision2D collider)
	{
		print("I am the attacking");
		if(collider.gameObject.tag == "Player")
			Player.GetComponent<hopefullyhealthbar>().TakeDamage(damage);
	}
}
