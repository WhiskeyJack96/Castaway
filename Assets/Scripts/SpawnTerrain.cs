using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour {
	public GameObject Terrain;


	// Use this for initialization
	void Start () {
		
	}
	public void spawn()
    {
    	if(Terrain != null)
    	{
    		Instantiate(Terrain, transform.position, new Quaternion(0,0,0,0));
    	}
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
