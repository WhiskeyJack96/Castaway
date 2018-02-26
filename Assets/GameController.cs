using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int MapSize;
    public Vector3 spawn;
    public GameObject Player;
    public NoiseMap map;
    public int diff = 2;

	// Use this for initialization
	void Start () {
        //diff = PlayerPrefs.GetInt("Difficulty Setting");
        map.listx = map.listy= map.listy*diff;
        int x = (int)map.listx / 2;
        int y = (int)map.listy / 2;
        spawn = new Vector3(x*.32f,y*.32f,0);
		Player.transform.position = spawn; //Spawn Player
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
