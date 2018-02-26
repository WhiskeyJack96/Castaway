using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

public int scorenum;
private int totalscore;
public bool death = false;
private int GameSeconds;
public int mobshift = 5;


	// Use this for initialization
	void Start () {
		scorenum = 0;
		totalscore = 0;
		InvokeRepeating("timer", 0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//death = GetComponent<hopefullyhealthbar>.isDead;
		//if (GetComponent<hopefullyhealthbar>.isDead)
		if (death)
		{	
			GetComponent<ScoreController>().totaller();
			CancelInvoke();
		}
		
	}
	public void timer() 
	{	
		++scorenum;
		++GameSeconds;
		
	}
	public void score(int change)
	{
		scorenum += change;
	}

	public void timeweight()
	{
		if (GameSeconds > 59)
		{
			mobshift += 5;
			GetComponent<MobSpawn>().enemies += mobshift;
			GameSeconds -= 60;
		}
	}
}
