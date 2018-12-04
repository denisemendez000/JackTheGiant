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
    private Text scoreText, CoinText, LifeText, GameOverScoreText, GameOverCoinText;

    [SerializeField]
    private GameObject PausePanel, GameOverPanel, ReadyButton;

    void Start()
    {
        Time.timeScale = 0f;
    }


    void Awake()
    {
        MakeInstance();
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

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        ReadyButton.SetActive(false);

    }
    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        GameOverPanel.SetActive(true);
        GameOverCoinText.text = "x" + finalCoinScore;
        GameOverScoreText.text = "x" + finalScore;
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GamePlayScene");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
