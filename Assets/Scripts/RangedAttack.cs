using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

	public GameObject arrow;
	public float arrowSpeed = 10;
	private Rigidbody2D rb;
	private bool canshoot = true;
	int time = 1;
	public int ammo = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1) && canshoot) { //Right Mouse Button to shoot
			if (ammo > 0) {
				GameObject Iarrow;
				Iarrow = Instantiate (arrow, transform.position + new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
				rb = Iarrow.GetComponent<Rigidbody2D> ();
				Vector3 mouse = Input.mousePosition;
				mouse.z = 10;
				mouse = Camera.main.ScreenToWorldPoint (mouse);
				Vector3 player = transform.position;
				float x = mouse.x - player.x;
				float y = mouse.y - player.y;
				Vector3 vel = new Vector3 (x, y, 0);
				vel =arrowSpeed * vel.normalized;
				rb.velocity = vel;
				StartCoroutine (cooldown (time));
				ammo = ammo - 1;
			}
		}
	}
	public void addammo(int amount){
		ammo = ammo + 1;
	}
	IEnumerator cooldown(int time){
		canshoot = false;
		yield return new WaitForSeconds(time);
		canshoot =true;
	}
}
