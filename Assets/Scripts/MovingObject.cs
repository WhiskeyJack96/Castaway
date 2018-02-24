using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
	public int speed;
	public float movetime = 0.1f;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;
	// Use this for initialization
	protected void Start () {
		
		boxCollider = GetCompenent<BoxCollider2D>();
		rb2D = GetCompenent<Rigidbody2D>();
		inverseMoveTime = 1f / movetime

	}
	protected bool Move (int, xDir, yDir, out RaycastHit2D hit)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);

		boxCollider.enabled  = false;
		hit = Physics2D.Linecast (start, end, blockinglayer);
		boxCollider.enabled = true;

		if (hit.transform == null)
		{
			StartCoroutine(SmoothMovement (end));
			return true;
		}

		return false
	}
	
	protected IEnumberator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance =  (transform.position - end).sqrMagnitude;

		while(sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPostion = Vector3.MoveTowards (rb2D.postion, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition(newPostion);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null
		}
	}

	protected virtual void AttemptMove <T>  (int xDir, int yDir)
		where T: Component
	{
		RaycastHit2D hit;
		bool canMove = Move (xDir, yDir, out hit);

		if (hit.transform ==  null)
			return;
		T hitComponent = hit.transform.GetCompenent<T>();

		if (!canMove && hitComponent != null)
			OnCantMove(hitComponent);
	}

	protected abstract void OnCantMove <T> (T component)
		where T: Component;
	
}
