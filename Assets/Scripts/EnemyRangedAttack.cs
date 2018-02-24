using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour {

	public GameObject arrow;
	public float arrowSpeed = 150f;
	private Rigidbody2D rb;
	private bool canshoot = true;
	int time = 4;
	public GameObject Player;
	public bool range;
	private Vector3 movespeed;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
	}
		
	// Update is called once per frame
	//void Update () {
	//	if (Input.GetMouseButton (1) && canshoot) { //Right Mouse Button to shoot
	//		if (ammo > 0) {
	//			GameObject Iarrow;
	//			Iarrow = Instantiate (arrow, transform.position + new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
	//			rb = Iarrow.GetComponent<Rigidbody2D> ();
	//			Vector3 mouse = Input.mousePosition;
	//			mouse.z = 10;
	//			mouse = Camera.main.ScreenToWorldPoint (mouse);
	//			Vector3 player = transform.position;
	//			float x = mouse.x - player.x;
	//			float y = mouse.y - player.y;
	//			Vector3 vel = new Vector3 (x, y, 0);
	//			vel = vel / vel.magnitude;
	//			rb.velocity = vel;
	//			StartCoroutine (cooldown (time));
	//			ammo = ammo - 1;
	//		}
	//	}
	//}


	public void inrange(bool inrange) //From the movement, is passed True if the unit is in range, False otherwise
	{
		range = inrange;

	}

	void FixedUpdate ()
	{
		if (canshoot && range) //Makes an arrow, launches arrow at player's current location, can optimize with multiplication
		{
			GameObject Iarrow;
			Iarrow = Instantiate (arrow, transform.position + new Vector3 (0,0,0), new Quaternion(0,0,0,0));
			rb = Iarrow.GetComponent<Rigidbody2D>();
			movespeed = Player.GetComponent<Rigidbody2D>().velocity;
			Vector3 toplayer = Player.transform.position - transform.position;

			//ME FIDDLING AROUND WITH PREDICTIVE SHOOTING, CAN'T QUITE FIGURE IT OUT 
			//Vector3 predict = ((transform.position.x - (arrowSpeed/movespeed.x)*Player.transform.position.x)/(1-(arrowSpeed/movespeed.x)), (transform.position.y - (arrowSpeed/movespeed.y)*Player.transform.position.y)/(1-(arrowSpeed/movespeed.y)), 0);                                             ).normalized
			//Vector3 predict = (transform.position - (arrowSpeed/movespeed.magnitude)) / (1 -  (arrowSpeed/movespeed.magnitude));
			//Vector3 predict = - ((arrowSpeed / (arrowSpeed - movespeed.magnitude)) * toplayer).normalized;
			//Vector3 newtoplayer = toplayer + movespeed           

			rb.velocity = toplayer.normalized * arrowSpeed;
			print("I have you now!");
			StartCoroutine (cooldown (time));

		}
	}

	//public void addammo(int amount){
	//	ammo = ammo + 1;
	//}
	IEnumerator cooldown(int time){ //Forces the skeleton to wait after firing an arrow
		canshoot = false;
		yield return new WaitForSeconds(time);
		canshoot =true;
	}
}
