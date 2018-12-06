using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OPtionsController : MonoBehaviour {

    [SerializeField]
    private GameObject easySign, medSign, hardSign;
    
    // Use this for initialization
    void Start () {
        SetTheDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetTheDifficulty()
    {
        if (GamePreferencesScript.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");

        }
        if (GamePreferencesScript.GetMedDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (GamePreferencesScript.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }

    }
    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
//                easySign.SetActive(true);
                medSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
 //               medSign.SetActive(true);
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "hard":
  //              hardSign.SetActive(true);
                medSign.SetActive(false);
                easySign.SetActive(false);
                break;

        }
    }

    public void EasyDifficulty()
    {
        GamePreferencesScript.SetEasyDifficulty(1);
        GamePreferencesScript.SetMedDifficulty(0);
        GamePreferencesScript.SetHardDifficulty(0);

        easySign.SetActive(true);
        medSign.SetActive(false);
        hardSign.SetActive(false);
    }
    public void MedDifficulty()
    {
        GamePreferencesScript.SetEasyDifficulty(0);
        GamePreferencesScript.SetMedDifficulty(1);
        GamePreferencesScript.SetHardDifficulty(0);
        easySign.SetActive(false);
        medSign.SetActive(true);
        hardSign.SetActive(false);


    }
    public void HardDifficulty()
    {
        GamePreferencesScript.SetEasyDifficulty(0);
        GamePreferencesScript.SetMedDifficulty(0);
        GamePreferencesScript.SetHardDifficulty(1);
        easySign.SetActive(false);
        medSign.SetActive(false);
        hardSign.SetActive(true);


    }


    public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
