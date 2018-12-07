using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
      //  PlayerPrefs.DeleteAll();
    }
	

    public void StartGame()
    {
        GameManagerScript.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("GameplayScene");
    }

    public void HighScoreScene()
    {
        SceneManager.LoadScene("HighScoreScene");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {

    }
}
