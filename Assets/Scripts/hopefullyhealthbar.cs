using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hopefullyhealthbar : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider;

    public GameObject DS;
    public AudioClip damageTaken;
    public AudioClip playerDead;
    public AudioClip gameStart;

    public bool isDead = false;
    //bool damaged;

    void Awake()
    {
        currentHealth = maxHealth;
        //SoundManager.instance.PlaySingle(gameStart);
    }

    public void TakeDamage (float amount)
    {
        //damaged = true;
        currentHealth -= amount;
        if (amount > 0)
            SoundManager.instance.RandomizeSfx(damageTaken);
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthSlider.value = ((int)currentHealth);
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        SoundManager.instance.PlaySingle(playerDead);
        isDead = true;
        GameObject.Find("GameController").GetComponent<Timer>().death = true;
        DS.SetActive(true);
        GameObject.Find("Everything").SetActive(false);
        Destroy(gameObject);
        SoundManager.instance.musicSource.Stop();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
