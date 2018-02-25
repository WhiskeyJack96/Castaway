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
	public float movemod;        // Set by Biome in Mob Spawn and used to increase movespeed and health
 	public float healthmod;

	// Use this for initialization
	void Start () {
		rig =  GetComponent<Rigidbody2D>();
		float thealth = zhealth * (Random.Range(1,2)/2f + .25f);  
		health = GetComponent<EnemyHealth>();
		health.setHealth(thealth);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		playerx = Player.transform.position.x;
		playery = Player.transform.position.y;
		// new Vector3 distance
		face();
		move();
	}

	void face()
	{
		Vector3 player = Player.transform.position;
		Vector3 mob = transform.position;
		float x = player.x - mob.x;
		float y = player.y - mob.y;
		float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);			
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
