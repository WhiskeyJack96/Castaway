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
	private string biome;
	private float chargemod = 1;
	private float waitmod = 1;
	private float shealthmod = 1;
	private float rangemod = 1;
	private float zhealthmod = 1;
	private float movemod = 1;
	public LayerMask mask;
	public Color colorchange;
	// Use this for initialization
	//timer for spawn rate/score
	void Start () {
		Player = GameObject.Find("Player");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		varpos();
		if (able)
		{
		//print(v3Pos);
		spawn();
		}

	}

	string BiomeGet()
	{
		//Debug.DrawRay(transform.position, transform.forward*100, Color.red, 3f);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,100f,mask);
		biome = hit.transform.gameObject.name;
		//print(hit.transform.gameObject.name);
		return biome;

	}

	void ModGet(string biome)
	{
		if (biome == "Grassy(Clone)")
		{
			colorchange  =  new Color(1,1,1,1);
			chargemod  = 1f;
			waitmod = 1f;
			shealthmod = 0.75f;
			rangemod = 0.5f;
			zhealthmod = 1f;
			movemod = 1f;
		}
		else if (biome == "Sand(Clone)")
		{
			colorchange  = new Color(1, 0.92f, 0.016f, 1);
			chargemod  = 1.5f;
			waitmod = 0.5f;
			shealthmod = 1f;
			rangemod = 1f;
			zhealthmod = 1f;
			movemod = 1f;
		}
		else if (biome == "Mountain(Clone)")
		{
			colorchange  = new Color(.5f,.5f,.5f,1);
			chargemod  = 0.5f;
			waitmod = 1.5f;
			shealthmod = 2f;
			rangemod = 2f;
			zhealthmod = 1.5f ;
			movemod = 1f;
		}
		else if (biome == "BadSand(Clone)")
		{
			colorchange  = new Color(1,0,0,1);
			chargemod  = 2f;
			waitmod = 0.25f;
			shealthmod = 1f;
			rangemod = 1f;
			zhealthmod = 1.5f;
			movemod = 0.75f;
		}
		else if (biome == "Ice")
		{
			colorchange  = new Color(0,0,1,1);
			chargemod  = 0.5f;
			waitmod = 2f;
			shealthmod = 1.5f;
			rangemod = 1f;
			zhealthmod = 5f;
			movemod = 2f;
		}
	}



	void varpos()
	{
		int multpx = Random.Range(0,2);  // Returns either 0 or 1
		int multpy = Random.Range(0,2);
		float y = Random.Range(1f,10f)/10f;         // Returns a normalized random number for a weight
		float x = Random.Range(1f,10f)/10f;
		if (multpx == 0)
			spawnx = -x;
		else
			spawnx = 1-x;
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
			ModGet(BiomeGet());
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
		z.GetComponent<Zombie>().Play = Player;
		z.GetComponent<Zombie>().scaleBiome(zhealthmod, movemod, colorchange);
		//Give Zombie Class its biome modifiers
		return;
	}


	void sspawn() //Creates a Skeleton ideally slightly off screen)
	{
		GameObject s = Instantiate(ISkele, v3Pos, new Quaternion(0,0,0,0));
		s.GetComponent<Skeleton>().Play = Player;
		s.GetComponent<Skeleton>().scaleBiome(shealthmod, rangemod, colorchange);
		//Give Skeleton Class its biome modifiers
		return;
	}

	void bspawn()  //Creates a Boar ideally slightly off screen)
	{
		GameObject b = Instantiate(IBoar, v3Pos, new Quaternion(0,0,0,0));
		b.GetComponent<Boar>().Play = Player;
		b.GetComponent<Boar>().scaleBiome(chargemod, waitmod, colorchange);
		//Give Boar Class its biome modifiers
		return;
	}


	IEnumerator delay(int time)
	{
		yield return new WaitForSeconds(time);
		able = true;
		spawn();
	}
}
