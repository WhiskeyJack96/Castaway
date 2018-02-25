using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour {

	public int damage = 20;
	public int chargespeed = 25;
	public int chargedamage = 15;
	public float waittime = .5f;
	public int chargeduration = 1;
	public int cooldown = 1;
	public float bhealth = 15f;
	public float movespeed = 1f;
	public GameObject Player;
	private float playerx = 0f;
	private float playery = 0f;
	private Rigidbody2D rig;
	public float shootingdistance = 16f;
	private Vector3 movement;
	private Vector3 oldpos;
	private bool charging = false;
	private EnemyHealth health;

	// Use this for initialization
	void Start() {
		rig =  GetComponent<Rigidbody2D>();
		float mod = (Random.Range(1,2)/2f + .25f);
		float thealth = bhealth * mod;
		health = GetComponent<EnemyHealth>();
		health.setHealth(thealth);
		transform.localScale = new Vector3 (transform.localScale.x * mod, transform.localScale.y * mod, transform.localScale.z);
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
		if (movement.sqrMagnitude <= shootingdistance || charging)
		{
			if(!charging)
			{
				charging = true;
				attack();

				return;
			}
			else
			{
				return;
			}

		}
		else
			move();
		
	}

	void attack() //Charges set distance towards player location
	{
			// FACE THE PLAYER
			rig.velocity = new Vector3 (0,0,0);
			oldpos = movement;         // FINDS AND STORES PLAYER'S LOCATION
			movespeed += chargespeed;  // CHANGE SPEED TO SILLY HIGH VALUE
			StartCoroutine(wait (waittime)); // WAIT ABOUT HALF A SECOND
												  // MOVES TOWARD INITIAL PLAYER POSITION WITH NOW MODIFIED MOVESPEED
			StartCoroutine(duration (chargeduration)); // CHARGES FOR A SET TIME
			return;

			// MOVE SET DISTANCE TOWARDS PLAYER'S LOCATION AT START
			// SET DAMAGE TO NEW VALUE
			// CD
	}


	IEnumerator buffer(int time)
	{
		yield return new WaitForSeconds(time);
	}

	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
		damage += chargedamage;
		rig.velocity = oldpos.normalized * movespeed;
	}

	IEnumerator duration(int time)
	{
		yield return new WaitForSeconds(time);
		movespeed -= chargespeed;
		damage -= chargedamage;
		rig.velocity = new Vector3 (0,0,0);
		yield return new WaitForSeconds(time);
		charging = false;
	}



	void move() //Moves toward player
	{
		//Vector3 movement = new  Vector3(playerx - transform.position.x, playery - transform.position.y, 0).normalized * movespeed;
		rig.velocity = movement.normalized * movespeed;
		//rig.MovePosition(transform.position + movement);
	}

	public void OnCollisionEnter2D(Collision2D collider)
	{
		print("I finally hit it!");
		if(collider.gameObject.tag == "Player")
			Player.GetComponent<hopefullyhealthbar>().TakeDamage(damage);
	}
}