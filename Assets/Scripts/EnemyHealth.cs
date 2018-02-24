using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
