using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameStartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    // This is a Delegate
    private void OnEnable()
    {
        // Subscriting to event for scene loaded.
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameplayScene")
        {
            if (gameStartedAfterPlayerDied)
            {
                GamePlayControllerScript.instance.SetScore(score);
                GamePlayControllerScript.instance.SetCoin(coinScore);
                GamePlayControllerScript.instance.SetLife(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.lifeCount = lifeScore;
                PlayerScore.coinCount = coinScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.lifeCount = 2;
                PlayerScore.coinCount = 0;

                GamePlayControllerScript.instance.SetScore(0);
                GamePlayControllerScript.instance.SetCoin(0);
                GamePlayControllerScript.instance.SetLife(2);

            }

        }
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Awake () {
        MakeSingleton();
	}

    public void CheckGameStatus(int scores, int coinScores, int lifeScores)
    {
        if (lifeScore<0)
        {
            gameStartedFromMainMenu = false;
            gameStartedAfterPlayerDied = false;

            // Gameplay controller
            GamePlayControllerScript.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = scores;
            this.coinScore = coinScores;
            this.lifeScore = lifeScores;
            gameStartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GamePlayControllerScript.instance.PlayerDiedRestartTheGame();

        }
    }
	
}
