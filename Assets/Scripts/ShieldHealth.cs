using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour {
	public int health;
	public GameObject Shield;
	public int MaxHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Shield.SetActive (false);
		health = MaxHealth;

	}

	public void setHealth(int change)
	{
		health=change;
	}
	public void updateHealth(int change)
	{
		health -=change;
	}
	public int getHealth()
	{
		return health;
	}
}
