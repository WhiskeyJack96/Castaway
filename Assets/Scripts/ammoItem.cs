using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoItem : MonoBehaviour {
    public int ammoAmount = 5;

    public void OnTriggerEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collider.gameObject.GetComponent<RangedAttack>().addammo(ammoAmount);
        Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
