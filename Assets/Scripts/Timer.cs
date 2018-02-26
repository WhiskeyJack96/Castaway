/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

public int scorenum;
private int totalscore;
private bool death;


	// Use this for initialization
	void Start () {
		InvokeRepeating("timer", 0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//death = GetComponent<hopefullyhealthbar>.isDead;
		//if (GetComponent<hopefullyhealthbar>.isDead)
		{
			totalscore = scorenum;
			print(totalscore);
			CancelInvoke();
		}
	}
	public void timer() 
	{
		++scorenum;
		
	}
	public void score(int change)
	{
		scorenum += change;
	}

}*/
