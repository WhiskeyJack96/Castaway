using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour {
	//private Gamobj player;
	//gamobj.find(Player)
	public int timedelay = 4;
	public int enemies = 10;
	private bool able = true;
	public GameObject IZombie;
	public GameObject ISkele;
	public GameObject IBoar;
	public float delta = 40f;
	private Vector3 v3Pos;
	private float spawnx;
	private float spawny;
	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		//might be -transform.forward and needs mask configured and hit.collider is a thing
		//RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,length,mask);
		//if(hit)
		//{
			//do something
		//}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		varpos();
		//print(v3Pos);
		spawn();
	}


	void varpos()
	{
		int multpx = Random.Range(0,2);  // Returns either 0 or 1
		int multpy = Random.Range(0,2);
		float y = Random.Range(1,11)/10f;         // Returns a normalized random number to be added to a small number
		float x = Random.Range(1,11)/10f;
		if (multpx == 0)
			spawnx = -x;
		else
			spawnx = 1 + x;
		if (multpy ==0)
			spawny =  -y;
		else
			spawny = 1 + y;

	//	float spawnx = x * multpx;
	//	float spawny =  y * multpy;
		v3Pos = new Vector3(spawnx, spawny, 10);
		v3Pos = Camera.main.ViewportToWorldPoint(v3Pos);
		//Use random to add or sub a small number to edge of camera
	}


	void spawn() //Checks to see if we can spawn a mob
	{
		if (able && GameObject.FindGameObjectsWithTag("Enemy").Length < enemies)
		{

    		chooser();
    		able = false;
    	}
	}


	void chooser() //Finds a random number and runs spawn code depending on number
	{
		int seed = Random.Range(1,4);
		if (seed == 1)
		{	zspawn();
			StartCoroutine(delay (timedelay));
			return;
		}
		else if (seed == 2)
		{
			sspawn();
			StartCoroutine(delay (timedelay));
			return;
		}
		else if (seed == 3)
		{
			bspawn();
			StartCoroutine(delay (timedelay));
			return;
		}
	}


	void pointer()
	{

	}


	void zspawn()  //Creates a Zombie ideally slightly off screen)
	{
		GameObject z = Instantiate(IZombie, v3Pos, new Quaternion(0,0,0,0));
		z.GetComponent<Zombie>().Player = Player;
		return;
	}


	void sspawn() //Creates a Skeleton ideally slightly off screen)
	{
		GameObject s = Instantiate(ISkele, v3Pos, new Quaternion(0,0,0,0));
		s.GetComponent<Skeleton>().Player = Player;
		return;
	}

	void bspawn()  //Creates a Boar ideally slightly off screen)
	{
		GameObject b = Instantiate(IBoar, v3Pos, new Quaternion(0,0,0,0));
		b.GetComponent<Boar>().Player = Player;
		return;
	}


	IEnumerator delay(int time)
	{
		yield return new WaitForSeconds(time);
		able = true;
		spawn();
	}
}
