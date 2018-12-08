using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    public void SetMoveLeft(bool move)
    {
        this.moveLeft = move;
        this.moveRight = !move;
    }

    public void StopMoving()
    {
        this.moveLeft = this.moveRight = false;
        anim.SetBool("Walk", false);
    }

    private void Awake()
    {
        // First function that is executed
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

	void FixedUpdate () {

        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
        {
            MoveRight();
        }

    }

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector2 temp = transform.localScale;
        if (vel < maxVelocity)
        {
            forceX = -speed;
        }
        anim.SetBool("Walk", true);
        temp.x = -1.3f;
        transform.localScale = temp;
        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector2 temp = transform.localScale;
        if (vel < maxVelocity)
        {
            forceX = speed;
        }
        anim.SetBool("Walk", true);
        temp.x = 1.3f;
        transform.localScale = temp;
        myBody.AddForce(new Vector2(forceX, 0));
    }
}//

