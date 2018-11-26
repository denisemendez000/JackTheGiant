using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScalar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = sp.sprite.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldwidth = worldHeight / Screen.height * Screen.width;

        tempScale.x = worldwidth / width;

        transform.localScale = tempScale;
       
    }
	

}
