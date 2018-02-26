using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour {
	public Text ScoreText;
	public GameObject GC;
	//public Score = GetComponent.GameController<>().;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Final Score is " + GC.GetComponent<ScoreController>().total;
	}

	public void RestartBtn()
	{
		SceneManager.LoadScene ("TestMain");
	}
	public void MainMenuBtn()
	{
		SceneManager.LoadScene ("Main Menu");
	}
}
