using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
