using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour {

	public int timedelay = 4;
	public int enemies = 10;
	private bool able = true;
	public GameObject IZombie;
	public GameObject ISkele;
	public GameObject IBoar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawn();
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

	void zspawn()  //Creates a Zombie ideally slightly off screen)
	{
		Instantiate(IZombie, new Vector3 (0,0,0), new Quaternion(0,0,0,0));
		return;
	}


	void sspawn() //Creates a Skeleton ideally slightly off screen)
	{
		Instantiate(ISkele, new Vector3(0,0,0), new Quaternion(0,0,0,0));
		return;
	}

	void bspawn()  //Creates a Boar ideally slightly off screen)
	{
		Instantiate(IBoar, new Vector3(0,0,0), new Quaternion(0,0,0,0));
		return;
	}


	IEnumerator delay(int time)
	{
		yield return new WaitForSeconds(time);
		able = true;
		spawn();
	}
}
