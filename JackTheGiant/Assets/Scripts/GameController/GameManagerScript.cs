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

    // Use this for initialization
    void Awake()
    {
        MakeSingleton();
    }
    // Use this for initialization
    void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferencesScript.SetEasyDifficulty(0);
            GamePreferencesScript.SetEasyDifficultyScore(0);
            GamePreferencesScript.SetEasyDifficultyScoreCoin(0);

            GamePreferencesScript.SetMedDifficulty(1);
            GamePreferencesScript.SetMedDifficultyScore(0);
            GamePreferencesScript.SetMedDifficultyScoreCoin(0);
       
            GamePreferencesScript.SetHardDifficulty(0);
            GamePreferencesScript.SetHardDifficultyScore(0);
            GamePreferencesScript.SetHardDifficultyScoreCoin(0);

            GamePreferencesScript.SetIsMusicOn(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }


    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlayScene")
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



    public void CheckGameStatus(int scores, int coinScores, int lifeScores)
    {
        if (lifeScores <= 0)
        {
            if(GamePreferencesScript.GetEasyDifficulty() == 1)
            {
                int highScore = GamePreferencesScript.GetEasyDifficultyScore();
                int coin = GamePreferencesScript.GetEasyDifficultyScoreCoin();

                if (scores > highScore)
                {
                    GamePreferencesScript.SetEasyDifficultyScore(scores);
                }

                if (coinScores > coin)
                {
                    GamePreferencesScript.SetEasyDifficultyScoreCoin(coinScores);
                }
            }

            if (GamePreferencesScript.GetMedDifficulty() == 1)
            {
                int highScore = GamePreferencesScript.GetMedDifficultyScore();
                int coin = GamePreferencesScript.GetMedDifficultyScoreCoin();
                if (scores > highScore)
                {
                    GamePreferencesScript.SetMedDifficultyScore(scores);
                }

                if (coinScores > coin)
                {
                    GamePreferencesScript.SetMedDifficultyScoreCoin(coinScores);
                }
            }

            if (GamePreferencesScript.GetHardDifficulty() == 1)
            {
                int highScore = GamePreferencesScript.GetHardDifficultyScore();
                int coin = GamePreferencesScript.GetHardDifficultyScoreCoiny();
                if (scores > highScore)
                {
                    GamePreferencesScript.SetHardDifficultyScore(scores);
                }

                if (coinScores > coin)
                {
                    GamePreferencesScript.SetHardDifficultyScoreCoin(coinScores);
                }
            }

            gameStartedFromMainMenu = false;
            gameStartedAfterPlayerDied = false;

            // Gameplay controller
            GamePlayControllerScript.instance.GameOverShowPanel(scores, coinScores);
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
