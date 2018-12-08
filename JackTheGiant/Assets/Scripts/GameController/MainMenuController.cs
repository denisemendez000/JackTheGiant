using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
        
        if (!GamePreferencesScript.OnlyOnce)
        {
           PlayerPrefs.DeleteAll();
            GamePreferencesScript.OnlyOnce = true;
        }

    }
	
    void CheckToPlayMusic()
    {
        if (GamePreferencesScript.GetIsMusicOn() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }
        MusicController.instance.PlayMusic(false);
        musicBtn.image.sprite = musicIcons[1];
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
        if (GamePreferencesScript.GetIsMusicOn() == 0)
        {
            GamePreferencesScript.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }
        else if(GamePreferencesScript.GetIsMusicOn() == 1)
        {
            GamePreferencesScript.SetIsMusicOn(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }
}
