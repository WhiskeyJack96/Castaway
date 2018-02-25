using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResource : MonoBehaviour {
	public string resource;
	private int incamount = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			collider.gameObject.GetComponent<ResourceController>().addresource(resource, incamount);
			Destroy(this.gameObject);
		}


	}
}

