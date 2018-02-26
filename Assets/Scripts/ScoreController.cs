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
		InvokeRepeating("setter",0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void enemies()
	{
		fromenemies += 5;
	}

	public void changeshield(int amount)
	{
		fromshield += amount;
	}

	public void changeroll(int amount)
	{
		fromroll += amount;
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
