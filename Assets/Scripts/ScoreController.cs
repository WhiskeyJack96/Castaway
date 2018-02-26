using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	private int fromtime;
	private int fromwood;
	private int fromshield = 0;
	private int fromroll = 0;
	private int fromenemies = 0;
	private int total;
	private bool death;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<hopefullyhealthbar>().isDead)
			{
				totaller();
			}
	}

	public void enemies()
	{
		fromenemies += 1;
	}

	public void changeshield(int amount)
	{
		fromshield += amount;
	}

	public void changeroll(int amount)
	{
		fromroll += amount;
	}

	public void doesadie()
	{
	

	}

	public void setter()
	{
		fromtime = GetComponent<Timer>().scorenum;
		fromwood = GetComponent<ResourceController>().TotalWood;
	}

	public void totaller()
	{
		total = fromtime + fromwood + fromshield + fromroll +  fromenemies;
	}
}
