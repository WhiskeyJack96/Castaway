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
				Vector3 mouse = Input.mousePosition;
				mouse.z = 10;
				mouse = Camera.main.ScreenToWorldPoint (mouse);
				Vector3 player = transform.position;
				float x = mouse.x - player.x;
				float y = mouse.y - player.y;
				Vector3 vel = new Vector3 (x, y, 0);
				vel =arrowSpeed * vel.normalized;
				float angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
				Iarrow = Instantiate (arrow, transform.position + vel.normalized*0.25f, new Quaternion (0, 0, 0, 0));
				rb = Iarrow.GetComponent<Rigidbody2D> ();
				rb.velocity = vel;
       			Iarrow.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
       			Iarrow.GetComponent<arrow>().ttag = this.gameObject.tag;
				StartCoroutine (cooldown (time));
				ammo = ammo - 1;
			}
		}
	}
	public void addammo(int amount){
		ammo = ammo + amount;
	}
	IEnumerator cooldown(int time){
		canshoot = false;
		yield return new WaitForSeconds(time);
		canshoot =true;
	}
}
