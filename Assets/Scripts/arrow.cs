using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
	
	public int arrowdamage = 15;
	public GameObject Player;
	private Rigidbody2D rig;

	void OnBecameInvisible ()
	{
		Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			print("It's a hit");
			collider.gameObject.GetComponent<hopefullyhealthbar>().TakeDamage(arrowdamage);
			Destroy(this.gameObject);
			return;
		}
		if (collider.gameObject.tag == "Shield") {
			collider.gameObject.GetComponent<ShieldHealth> ().updateHealth (arrowdamage);
			Destroy (this.gameObject);
		}
	}
}