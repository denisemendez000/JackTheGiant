using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;
    private Vector3 previousPostion;
    private bool countScore;

    public static int scoreCount, lifeCount, coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    // Use this for initialization
    void Start () {
        previousPostion = transform.position;
        countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
        // We want to update every frame
        CountScore();
	}

    void CountScore()
    {
        if (countScore)
        {
            // less than because we are going down... aka -y
            //  up is ++ y
            //  left is -x
            //  right is +x
            if(transform.position.y < previousPostion.y)
            {
                scoreCount++;
                GamePlayControllerScript.instance.SetScore(scoreCount);
            }
            previousPostion = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            scoreCount += 200;
            coinCount++;
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            // Turn off the coin 
            collision.gameObject.SetActive(false);
            GamePlayControllerScript.instance.SetCoin(coinCount);
            GamePlayControllerScript.instance.SetScore(scoreCount);
        }

        if (collision.tag == "Life")
        {
            scoreCount += 300;
            lifeCount++;
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            // Turn off the coin 
            collision.gameObject.SetActive(false);
            GamePlayControllerScript.instance.SetLife(lifeCount);
            GamePlayControllerScript.instance.SetScore(scoreCount);
        }

        if(collision.tag == "Bounds" || collision.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            //number is arbitrary Just want to move the play out of the screen
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManagerScript.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }

        //if (collision.tag == "Deadly")
        //{
        //    cameraScript.moveCamera = false;
        //    countScore = false;
        //
        //    //number is arbitrary
        //    transform.position = new Vector3(500, 500, 0);
        //    lifeCount--;
        //
        //    GameManagerScript.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        //}
    }   //
}
