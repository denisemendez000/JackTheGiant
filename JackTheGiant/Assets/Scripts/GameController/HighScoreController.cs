using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

    // Use this for initialization
    void Start()
    {
        SetScoreBasedonDifficulty();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();

    }

    void SetScoreBasedonDifficulty()
    {
        if (GamePreferencesScript.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferencesScript.GetEasyDifficultyScore(), GamePreferencesScript.GetEasyDifficultyScoreCoin());
        }

        if (GamePreferencesScript.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferencesScript.GetHardDifficultyScore(), GamePreferencesScript.GetHardDifficultyScoreCoiny());
        }
 
        if (GamePreferencesScript.GetMedDifficulty() == 1)
        {
           SetScore(GamePreferencesScript.GetMedDifficultyScore(), GamePreferencesScript.GetMedDifficultyScoreCoin());
        }
    }

    public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
