using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    public GameObject Player{get;set;}
    protected Rigidbody2D rig;
    protected EnemyHealth healthTracker;

    protected float BaseHealth{get; set;}
    protected float Movespeed{get;set;}
    protected float AttackDamage{get;set;}

    protected float followRange{get;set;}

    protected Color color{get;set;}

    protected bool InRange{get;set;}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

    protected virtual void initializeValues()
    {
        rig = GetComponent<Rigidbody2D>();
        healthTracker = GetComponent<EnemyHealth>();
    }

    protected virtual void face()
    {
        Vector3 player = Player.transform.position;
        Vector3 mob = transform.position;
        float x = player.x - mob.x;
        float y = player.y - mob.y;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -270, Vector3.forward);         
    }

    protected virtual void move()
    {

        Vector3 movement = new  Vector3(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y, 0);
        
        if(movement.sqrMagnitude < Mathf.Pow(followRange,2))
        {
            InRange = true;
            Attack();
        }
        else
        {
            InRange = false;
            rig.velocity = movement.normalized * Movespeed;
        }
        //rig.MovePosition(transform.position + movement);
    }

    protected virtual void Attack()
    {
        return;
    }

    protected virtual void scaleSizeandHealth()
    {
        float mod = (Random.Range(1,2)/2f + .25f);
        BaseHealth *=mod;
        transform.localScale = new Vector3 (transform.localScale.x * mod, transform.localScale.y * mod, transform.localScale.z);
    }

    public virtual void scaleBiome(float mod1, float mod2, Color colorchange)
    {
        return;
    }

}
