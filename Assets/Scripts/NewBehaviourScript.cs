using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MovingObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		down = Getkeydown(keycode.s)
		up = Getkeyup(keycode.w)
		left = Getkeyleft(keycode.a)
		right = Getkeyright(keycode.d)
		if (down){
			MovingObject.move()
		}
	}
}
