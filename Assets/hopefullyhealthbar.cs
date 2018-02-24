using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hopefullyhealthbar : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public sliding healthSlider;

    bool isDead = false;
    bool damaged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        print("ouch");
        currentHealth -= amount;
        healthSlider.updateSlider(currentHealth);
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        print("died");
        isDead = true;
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
