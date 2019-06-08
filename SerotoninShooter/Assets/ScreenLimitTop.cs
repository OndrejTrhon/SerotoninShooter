using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimitTop : MonoBehaviour
{

    
        // Just destroys passing objects

    void Start()
    {
    }  

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) //the code below is only called when an object that includes a collider enters the trigger 2D collider attached to the screen limit object.
{
    Destroy (other.gameObject); //Destroy the object that passes through the screen limit collider.
    
}
}
