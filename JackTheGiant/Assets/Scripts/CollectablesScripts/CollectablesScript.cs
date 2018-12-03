using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour {

    // This is a primitive for Unit when a game object is disabled or enabled.
    private void OnEnable()
    {
        // Invokes the name of the funciton and the time
        // Wait 6 seconds before disableing
        Invoke("DisableCollectable", 6f);
        
    }



    void DisableCollectable()
    {
        gameObject.SetActive(false);
    }


}
