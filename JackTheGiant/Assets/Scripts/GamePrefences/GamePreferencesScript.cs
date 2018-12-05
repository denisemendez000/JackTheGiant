using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferencesScript {

    public static string EasyDifficulty = "EasyDifficulty";
    public static string MedDifficulty = "MedDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MedDifficultyHighScore = "MedDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string MedDifficultyScoreCoin= "MedDifficultyScoreCoin";
    public static string HardDifficultyScoreCoin = "HardDifficultyScoreCoin";
    public static string EasyDifficultyScoreCoin = "EasyDifficultyScoreCoin";

    public static string IsMusicOn = "IsMusicOn";

    // We are going to use integers to represent Boolean vars
    // 0 is false

    public static void SetEasyDifficulty (int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.EasyDifficulty, state);
    }
    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.EasyDifficulty);
    }

    public static void SetMedDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.MedDifficulty, state);
    }
    public static int GetMedDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.MedDifficulty);
    }

    public static void SetHardDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.HardDifficulty, state);
    }
    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.HardDifficulty);
    }

    public static void SetEasyDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.EasyDifficultyHighScore, state);
    }
    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.EasyDifficultyHighScore);
    }

    public static void SetMedDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.MedDifficultyHighScore, state);
    }
    public static int GetMedDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.MedDifficultyHighScore);
    }

    public static void SetHardDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.HardDifficultyHighScore, state);
    }
    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.HardDifficultyHighScore);
    }

    public static void SetMedDifficultyScoreCoin(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.MedDifficultyScoreCoin, state);
    }
    public static int GetMedDifficultyScoreCoin()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.MedDifficultyScoreCoin);
    }

    public static void SetHardDifficultyScoreCoin(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.HardDifficultyScoreCoin, state);
    }
    public static int GetHardDifficultyScoreCoiny()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.HardDifficultyScoreCoin);
    }

    public static void SetEasyDifficultyScoreCoin(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.EasyDifficultyScoreCoin, state);
    }
    public static int GetEasyDifficultyScoreCoin()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.EasyDifficultyScoreCoin);
    }

    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(GamePreferencesScript.IsMusicOn, state);
    }

    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(GamePreferencesScript.IsMusicOn);
    }
}
