using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawnerScript : MonoBehaviour {

    private GameObject[] backgrounds;
    float lastY;
    
	// Use this for initialization
	void Start () {
        GetBackgroundAndSetLastY();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Backgrounds");
        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i< backgrounds.Length; i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Backgrounds")
        {
            if (collision.transform.position.y == lastY)
            {
                Vector3 temp = collision.transform.position;
                float height = ((BoxCollider2D)collision).size.y;
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].gameObject.SetActive(true);                      
                    }
                }
            }
        }
    }
}
