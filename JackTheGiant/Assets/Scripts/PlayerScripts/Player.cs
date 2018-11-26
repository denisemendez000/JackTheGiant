using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        // First function that is executed
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Called every few frames... Best for physics code.
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector2 temp = transform.localScale;

        float h = Input.GetAxisRaw("Horizontal");
        if (h> 0)
        {
            if (vel <maxVelocity )
            {
                forceX = speed;
            }
            anim.SetBool("Walk", true);
            temp.x = 1.3f;
            transform.localScale = temp;
        }
        else if ( h< 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }
            anim.SetBool("Walk", true);
            temp.x = -1.3f;
            transform.localScale = temp;
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
}  //Player
