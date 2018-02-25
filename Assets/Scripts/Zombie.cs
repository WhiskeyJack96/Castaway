using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	public int damage = 20;
	public int zhealth =15;
	private EnemyHealth health;
	private float movespeed = 1f;
	public GameObject Player;
	private float playerx = 0f;
	private float playery = 0f;
	private Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		rig =  GetComponent<Rigidbody2D>();
		health = GetComponent<EnemyHealth>();
		health.setHealth(zhealth);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		playerx = Player.transform.position.x;
		playery = Player.transform.position.y;
		// new Vector3 distance
		move();
	}

	//void AttemptMove() 
	//{
	//	if
	//}


	void move()
	{

		Vector3 movement = new  Vector3(playerx - transform.position.x, playery - transform.position.y, 0).normalized * movespeed;
		rig.velocity = movement;
		//rig.MovePosition(transform.position + movement);
	}

	public void OnCollisionEnter2D(Collision2D collider)
	{
		print("I am the attacking");
		if(collider.gameObject.tag == "Player")
			Player.GetComponent<hopefullyhealthbar>().TakeDamage(damage);
	}
}
