using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRoll: MonoBehaviour {
	
	public int cdtime = 1;
	public float itime  = .1f;
	private GameObject player;
	float rollspeed;
	private bool canroll = true;
	public bool isrolling = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		float movespeed = player.GetComponent<RoughMovement> ().movespeed;
		rollspeed = 2 * movespeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && canroll)
		{
			player.GetComponent<Collider2D>().enabled = false;
			player.GetComponent<RoughMovement>().isrolling = true;
			Vector3 mouse = Input.mousePosition;
			mouse.z = 10;
			mouse = Camera.main.ScreenToWorldPoint (mouse);
			//print (mouse);
			Vector3 ploc = transform.position; //player location
			float x = mouse.x - ploc.x;
			float y = mouse.y - ploc.y;
			Vector3 RollDir = new Vector3 (x,y,0);
			RollDir = RollDir.normalized;
			//print (RollDir);
			Vector3 rb = player.GetComponent<Rigidbody2D> ().velocity;
			Vector3 Rollvec = rollspeed * RollDir;
			player.GetComponent<Rigidbody2D>().velocity = Rollvec;
			//print (Rollvec);
			StartCoroutine (iframes (itime, rb));
			//StartCoroutine(rotate(itime));
			StartCoroutine (cooldown (cdtime));
		}
	}
	IEnumerator cooldown(int cdtime){
		canroll = false;
		yield return new WaitForSeconds (cdtime);
		canroll = true;

	}
	IEnumerator iframes(float itime, Vector3 old){
		yield return new WaitForSeconds (itime);
		player.GetComponent<Rigidbody2D> ().velocity = old;
		player.GetComponent<RoughMovement>().isrolling = false;
		player.GetComponent<Collider2D>().enabled = true;

	}
	/*IEnumerator rotate(float itime)
	{
		float time = itime;
		float stepsize = 180/itime;
		//if z %90 ==0
		while (time >0 && stepsize < 180)
		{
			transform.Rotate(Vector3.up);
			stepsize+= stepsize;
			time-=Time.deltaTime;
		}
		yield return new WaitForSeconds(0);
	}*/
}