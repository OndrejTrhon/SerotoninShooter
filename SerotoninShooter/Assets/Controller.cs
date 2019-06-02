using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour

{
    public int TickTime;
    private int Level;
    private int Time;

    public Text LevelText;
    public Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        Level = 10;
        Time = 0;
        InvokeRepeating("Ticker", 1.0f, TickTime);
        InvokeRepeating("Clock", 1.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E)) {
              Level = Level + 3;
              LevelText.text = "Level: " + Level.ToString ();

     }
          
    }

    //Main ticking function

    void Clock() {
        Debug.Log("Time"); 
        if (Time <= 23) {
            Time = Time + 1;
        } else {
            Time = 0;
        }
        Debug.Log(Time);
        TimeText.text = "Time: " + Time.ToString ();
    }

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

    //UpdateDifficulty according to the level
    void UpdateDifficulty() {
        Debug.Log("UpdateDifficulty"); 
    }

    void TakeMedication() {
        Level = Level + 3;
        LevelText.text = "Level: " + Level.ToString ();
        CheckTime();
    }

    void CheckTime() {

        SetState();
    }

    void SetState() {
        Debug.Log("State"); 

    }
}