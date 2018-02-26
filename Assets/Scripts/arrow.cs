using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
	public string ttag;
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
		string t = collider.gameObject.tag;
		if(t == "Player" && t!=ttag)
		{
			print("It's a hit");
			collider.gameObject.GetComponent<hopefullyhealthbar>().TakeDamage(arrowdamage);
			Destroy(this.gameObject);
			return;
		}
		if (t== "Shield" && t!=ttag) {
			collider.gameObject.GetComponent<ShieldHealth>().updateHealth (arrowdamage);
			Destroy (this.gameObject);
		}
		if(t == "Enemy" && t!=ttag)
		{
			collider.gameObject.GetComponent<EnemyHealth>().updateHealth(arrowdamage);
			Destroy(this.gameObject);
			return;
		}
	}
}