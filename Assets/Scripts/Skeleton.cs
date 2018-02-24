using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	public int damage = 20;
	private int Health = 15;
	private float movespeed = 1f;
	public GameObject Player;
	private float playerx = 0f;
	private float playery = 0f;
	private Rigidbody2D rig;
	private float shootingdistance = 225f;
	private Vector3 movement;

	// Use this for initialization
	void Start () {
		rig =  GetComponent<Rigidbody2D>();
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		playerx = Player.transform.position.x;
		playery = Player.transform.position.y;
		movement = new Vector3 (playerx - transform.position.x,  playery - transform.position.y, 0);
		AttemptMove();
	}

	void AttemptMove() 
	{
		if (movement.sqrMagnitude <= shootingdistance)
		{
			rig.velocity = new Vector3 (0,0,0);
			return;
		}
		else
			move();
	}


	void move()
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
