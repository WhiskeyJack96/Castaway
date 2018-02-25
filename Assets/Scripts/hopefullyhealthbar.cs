using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hopefullyhealthbar : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
    public sliding healthSlider;

    bool isDead = false;
    bool damaged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (float amount)
    {
        damaged = true;
        print("ouch");
        currentHealth -= amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        //healthSlider.updateSlider(currentHealth);
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
