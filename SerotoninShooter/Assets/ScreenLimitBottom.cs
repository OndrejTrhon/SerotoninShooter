using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLimitBottom : MonoBehaviour
{

    public Text EnemiesLeftText;
    public int EnemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesLeft = 0;
    }  

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) //the code below is only called when an object that includes a collider enters the trigger 2D collider attached to the screen limit object.
{
    EnemiesLeft = EnemiesLeft +1;
    Destroy (other.gameObject); //Destroy the object that passes through the screen limit collider.
    EnemiesLeftText.text = "Serotonins missed: " + EnemiesLeft.ToString ();


}
}
