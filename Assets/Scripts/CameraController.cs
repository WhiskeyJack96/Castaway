using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

public GameObject Player;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);


		//Get player.transform.position, set camera position to this
		
	}
}
