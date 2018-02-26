using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShield : MonoBehaviour {

	public GameObject Shield;
	public float MaxTime;
	public float CDTime;
	private bool canshield = true;
	public int ShieldResource = 5;
	private Quaternion rot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && canshield) {
			if (ShieldResource > 0) {

				Shield.SetActive (true);
				StartCoroutine (cooldown (CDTime));
				ShieldResource = ShieldResource - 1;
				StartCoroutine (shielddeath (MaxTime));

			}
		
		}

	}
	public void addammo(int amount){
		ShieldResource = ShieldResource + amount;
	}
	IEnumerator cooldown(float CDTime){
		canshield = false;
		yield return new WaitForSeconds (CDTime);
		canshield = true;
	}
	IEnumerator shielddeath(float MaxTime){
		yield return new WaitForSeconds (MaxTime);
		Shield.SetActive (false);
	}
}
