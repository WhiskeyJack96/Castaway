using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	public int Health = 100;
	public int Speed = 50;
	public int Damage = 5

	// Use this for initialization
	protected override void Start () {
		
		base.Start();
	}
	

	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerGiveBuff (Collider2D  other)
	{
		if (other.tag == "Speed")
		{
			Speed = 75 //Currently permanent, would like to implement a timed duration
			return
		}

		if (other.tag == "DamageUp")
		{
			Damage = 8
			return
		}

		if (other.tag == "heal")
		{
			Health += 15
			return
		}

		elseif
		{
			return
		}
	}

	public void LoseHP (int loss)
	{
		Health -= loss;
		CheckIfGameover();
	}
	private void CheckIfGameover()
	{
		if (Health <= 0)
			// INSERT CODE FOR ENDING GAME
	}
}
