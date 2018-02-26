using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {
	private string Wood;
	public int TotalWood;
	private int amount;

	// Use this for initialization
	void Start () {
		TotalWood = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addresource(string resource, int amount)
	{
		
		if (resource == "Wood")
		{
			TotalWood  += amount;
			print("I picked up Wood!");
		
		}
	}

}
