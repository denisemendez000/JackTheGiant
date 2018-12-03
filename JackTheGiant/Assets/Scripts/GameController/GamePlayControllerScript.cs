using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayControllerScript : MonoBehaviour {

    // static means its a singleton...
    // We are makeing a reference to the class so we can access it in other scripts
    // we could do GamePlayControllerScript.instance.SomeMethod();
    // without haveing to create a var and getting a reference to the class
    public static GamePlayControllerScript instance;

    [SerializeField]
    private Text scoreText, CoinText, LifeText;

    [SerializeField]
    private GameObject PausePanel;

    void Awake()
    {
        MakeInstance();
    }
    
	// Use this for initialization
  	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetLife(int lifeScore)
    {
        LifeText.text = "x" + lifeScore;
    }

    public void SetCoin(int coinScore)
    {
        CoinText.text = "x" + coinScore;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
