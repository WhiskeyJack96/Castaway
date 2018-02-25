using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    private float MaxHealth;
    private float health;

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

    public void setHealth(float change)
    {
        MaxHealth=change;
        health = MaxHealth;
    }
    public void updateHealth(float change)
    {
        health -=change;
        if (health > MaxHealth)
            health = MaxHealth;
    }
    public float getHealth()
    {
        return health;
    }

}
