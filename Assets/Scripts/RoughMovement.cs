using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoughMovement : MonoBehaviour {

	public float movespeed = 4f;

	private Rigidbody2D rig;

	// Use this for initialization
	void Start () {

		rig = GetComponent<Rigidbody2D>();

		
	}
	
	// Update is called ~30 times per second
	void FixedUpdate () 
	{
		move();
	}

	void move()
	{
		float xmove = 0;
		float ymove = 0;
		if(Input.GetKey(KeyCode.W))
		{
			ymove = 1;
			
		}

		if(Input.GetKey(KeyCode.A))
		{
			xmove = -1;
		
		}

		if(Input.GetKey(KeyCode.S))
		{
			ymove = -1;
		
		}

		if(Input.GetKey(KeyCode.D))
		{
			xmove = 1;
		
		}

		Vector3 movement = new Vector3(xmove, ymove, 0); //NORMALIZE LATER FOR DIAGONAL MOVEMENT

		rig.velocity = movement.normalized * movespeed;	

	}

	
	/*protected IEnumberator SmoothMovement (Vector3 direction)
	{
	
		float sqrRemainingDistance = (transform.position - direction).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3  newposition = Vector3.MoveToward (rig.position, )
		}
	}
*/

}

