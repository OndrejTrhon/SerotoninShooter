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

    public SpawnMovingTargets Spawner;
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

        UpdateDifficulty();

     if (Input.GetKeyDown(KeyCode.E)) {
              TakeMedication();

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

    void TakeMedication() {
        CheckTime();
    }

    void CheckTime() {
         
        if (Time == 11 || Time == 12 || Time = 13) {
            Level = 10
        } else if (Time > 0 && Time < 4) {
        } else if (Time > 3 && Time < 8) {
        } else if (Time > 7 && Time < 11) {
            
        } else if (Time > 13 && Time < 18) {
            
        } else if (Time > 17 && Time < 21) {
            
        } else if (Time > 20 && Time < 25) {
            
        }
            


        SetState();

        

    }

    void SetState() {
        Debug.Log("State"); 

    }


    void UpdateDifficulty() {
        if (Level == 10) {
            Spawner.TimeThreshold = 1f;
        } else if (Level == 9) {
            Spawner.TimeThreshold = 0.9f;
        } else if (Level == 9) {
            Spawner.TimeThreshold = 0.9f;
        } else if (Level == 8) {
            Spawner.TimeThreshold = 0.8f;
        } else if (Level == 7) {
            Spawner.TimeThreshold = 0.7f;
        } else if (Level == 6) {
            Spawner.TimeThreshold = 0.6f;
        } else if (Level == 5) {
            Spawner.TimeThreshold = 0.5f;
        } else if (Level == 4) {
            Spawner.TimeThreshold = 0.4f;
        } else if (Level == 3) {
            Spawner.TimeThreshold = 0.3f;
        } else if (Level == 2) {
            Spawner.TimeThreshold = 0.2f;
        } else if (Level == 1) {
            Spawner.TimeThreshold = 0.1f;
        }
        
    }
}