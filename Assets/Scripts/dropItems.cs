using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItems : MonoBehaviour {
    public GameObject item;

    //instantiates items based on enemy type
    public void ChooseItem()
    {
        if(item != null)
        {
            Instantiate(item, transform.position + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
