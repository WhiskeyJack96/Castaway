using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {
	 
	void Start(){
		//int ds = PlayerPrefs.GetInt ("DifficultySetting");

	}
	public void NewGameBtn (string NewGame)
	{ 
		SceneManager.LoadScene (NewGame);

	}
	public void ExitGameBtn ()
	{
		Application.Quit ();
	}
	public void DifficultyInput (int ds)   //small/easy = 0, med/intermediate = 1, large/hard = 2
	{
		PlayerPrefs.SetInt ("DifficultySetting", ds);
	}
}