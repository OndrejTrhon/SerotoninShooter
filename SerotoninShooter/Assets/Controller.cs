    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour

{
    public int TickTime;
    private int Level;

    public Text LevelText;
    
    public GameObject SoundPlayer; 
    public GameObject SoundPlayer2;
    public GameObject SoundPlayer3;
    public GameObject SoundPlayer4;
    public GameObject SoundChecker;

    

    // Start is called before the first frame update
    void Start()
    {
        Level = 10;
        InvokeRepeating("Ticker", 1.0f, TickTime);
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    //Main ticking function
    void Ticker()
    {
              Debug.Log("Test"); 
              LevelObserver();
              Debug.Log(Level);
    }

    //function taking care of checking the level of antidepressant
    void LevelObserver() {
        Level--;
        LevelText.text = "Level: " + Level.ToString ();


    }

}