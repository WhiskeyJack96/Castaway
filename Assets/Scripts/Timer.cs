using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

public int scorenum;


	// Use this for initialization
	void Start () {
		InvokeRepeating(timer(),0,0.1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void timer() 
	{
		++scorenum;
		
	}
	public void score(int change)
	{
		scorenum += change;
	}

}
