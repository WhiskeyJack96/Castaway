using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {
	private string Stone;
	public int TotalStone;
	private string Wood;
	public int TotalWood;
	private int amount;

	// Use this for initialization
	void Start () {
		TotalStone = 5;
		TotalWood = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addresource(string resource, int amount)
	{
		if (resource == "Stone")
		{
			TotalStone += amount;
			print("I picked up Stone!");
		
		}
		else if (resource == "Wood")
		{
			TotalWood  += amount;
			print("I picked up Wood!");
		
		}
	}

}
