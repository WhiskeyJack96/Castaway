using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    private int MaxHealth;
    private int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            GetComponent<dropItems>().ChooseItem();
			Destroy(this.gameObject);
			return;
        }
	}

    public void setHealth(int change)
    {
        MaxHealth=change;
        health = MaxHealth;
    }
    public void updateHealth(int change)
    {
        health -=change;
        if (health > MaxHealth)
            health = MaxHealth;
    }
    public int getHealth()
    {
        return health;
    }

}
