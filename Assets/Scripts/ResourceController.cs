using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {
	private string Stone;
	public int TotalStone;
	private string Wood;
	public int TotalWood;
	private int amount;
	public GameObject wall;
	public bool canBuild = true;
	public float timer = .1f;
	public float wallhealth = 30f;

	// Use this for initialization
	void Start () {
		TotalStone = 5;
		TotalWood = 5;
	}
	
	// Update is called once per frame
	void Update () {
		place();	
	}

	public void addresource(string resource, int amount)
	{
		if (resource == "Stone")
		{
			TotalStone += amount;
			print("I picked up Stone!");
		
		}
		else if (resource == "Wood")
		{
			TotalWood  += amount;
			print("I picked up Wood!");
		
		}
	}

	public void place()
	{
		if(Input.GetKeyDown(KeyCode.F) && TotalWood > 0 && canBuild)
		{
			Vector3 mouse = Input.mousePosition;
			mouse.z = 10;
			mouse = Camera.main.ScreenToWorldPoint (mouse);
			wall = Instantiate(wall, mouse, new Quaternion(0,0,0,0));
			wall.GetComponent<EnemyHealth>().setHealth(wallhealth);
			StartCoroutine(cooldown(timer));

		}
	}

	IEnumerator cooldown(float timer){
        canBuild = false;
        yield return new WaitForSeconds(timer);
        canBuild = true;
    }
}
