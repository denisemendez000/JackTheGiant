using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float easySpeed = 3.2f;
    private float medSpeed = 4.0f;
    private float hardSpeed = 4.5f;

    private float speed = 1f, acceleration = 0.2f, maxSpeed = 3.2f;
    
    [HideInInspector]
    public bool moveCamera;

	// Use this for initialization
	void Start () {
        moveCamera = true;
        if (GamePreferencesScript.GetEasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }
        if (GamePreferencesScript.GetMedDifficulty() == 1)
        {
            maxSpeed = medSpeed;
        }
        if (GamePreferencesScript.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }


    }
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            MoveCamera();
        }
		
	}

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);
        // Will keep the temp.y from going further than the new position and behind the old position.
        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
