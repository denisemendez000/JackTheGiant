using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour , IPointerUpHandler, IPointerDownHandler{

    private PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            Debug.Log("Touching the left");
            playerMove.SetMoveLeft(true);
        }
        else
        {
            Debug.Log("Touching the left");
            playerMove.SetMoveLeft(false);
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        playerMove.StopMoving();
    }

}
