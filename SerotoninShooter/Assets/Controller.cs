using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour

{
    private int Level;
    //StartingLevel, for dev purposes only
 
    private int Time;
    //Time, starting time, for dev purposes only

    private int GameState;
    //1 = normal , 2 = soon, 3 = too soon, 4 = really soon, 5 = late, 6 = too late, 7 = really late

    public Text LevelText;
    public Text TimeText;
    public Text GameStateText;
    public Text TimeThresholdCheck;

    public SpawnMovingTargets Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Level = 12;
        Time = 0;
        GameState = 1;
        InvokeRepeating("Ticker", 1.0f, 1f);
        InvokeRepeating("Clock", 1.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //This is where you take antidepressants, yay
     if (Input.GetKeyDown(KeyCode.E)) {
              TakeMedication();
     }
          
    }

    //Clock only controls time

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

    //Tick is the main fucntion which is updated every second, setting the difficulty of the game
    void Ticker()
    {
        UpdateDifficulty();
        LevelObserver();
              Debug.Log(Level);
              GameStateText.text = "GameState: " + GameState.ToString ();
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
         
        if ((Time == 11) || (Time == 12) || (Time == 13)) {
            Level = 24;
            SetStateNormal();
        } else if (Time > 0 && Time < 4) {
            Level = 10;
            SetStateReallySoon();
        } else if (Time > 3 && Time < 8) {
            Level = 15;
            SetStateTooSoon();
        } else if (Time > 7 && Time < 11) {
            Level = 20;
            SetStateSoon();
        } else if (Time > 13 && Time < 18) {
            Level = 24;
            SetStateLate();
        } else if (Time > 17 && Time < 21) {
            Level = 24;
            SetStateTooLate();
        } else if (Time > 20 && Time < 25) {
            Level = 24;
            SetStateReallyLate();
        }

    }

    //SetState Functions, invoked by CheckTime() which alter gameplay according to when player took medication
    void SetStateNormal() {
        GameState = 1;
    }

    void SetStateSoon() {
        GameState = 2;
        Spawner.TimeThreshold = 0.8f; 
        Invoke("SetStateNormal",5);
    }

    void SetStateTooSoon() {
        GameState = 3;
        Spawner.TimeThreshold = 0.5f;
        Invoke("SetStateNormal",5);
    }

    void SetStateReallySoon() {
        GameState = 4;
        Spawner.TimeThreshold = 0.3f;
        Invoke("SetStateNormal",5);
    }

    void SetStateLate() {
        GameState = 5;
        Spawner.TimeThreshold = 0.8f;
        Invoke("SetStateNormal",5);
    }

    void SetStateTooLate() {
        GameState = 6;
        Spawner.TimeThreshold = 0.5f;
        Invoke("SetStateNormal",5);
    }

    void SetStateReallyLate() {
        GameState = 7;
        Spawner.TimeThreshold = 0.3f;
        Invoke("SetStateNormal",5);
    }

//UPDATE DIFFICULTY QUESTION

    void UpdateDifficulty() {
        
        if (GameState == 1) {
            if (Level == 24) {
                Spawner.TimeThreshold = 2f;
            } else if (Level == 23) {
                Spawner.TimeThreshold = 1.9f;
            } else if (Level == 22) {
                Spawner.TimeThreshold = 1.8f;
            } else if (Level == 21) {
                Spawner.TimeThreshold = 1.7f;
            } else if (Level == 20) {
                Spawner.TimeThreshold = 1.6f;
            } else if (Level == 19) {
                Spawner.TimeThreshold = 1.5f;
            } else if (Level == 18) {
                Spawner.TimeThreshold = 1.4f;
            } else if (Level == 17) {
                Spawner.TimeThreshold = 1.3f;
            } else if (Level == 16) {
                Spawner.TimeThreshold = 1.2f;
            } else if (Level == 15) {
                Spawner.TimeThreshold = 1.1f;
            } else if (Level == 14) {
                Spawner.TimeThreshold = 1.0f;
            } else if (Level == 13) {
                Spawner.TimeThreshold = 0.9f;
            } else if (Level == 12) {
                Spawner.TimeThreshold = 0.85f;
            } else if (Level == 11) {
                Spawner.TimeThreshold = 0.8f;
            } else if (Level == 10) {
                Spawner.TimeThreshold = 0.75f;
            } else if (Level == 9) {
                Spawner.TimeThreshold = 0.7f;
            } else if (Level == 8) {
                Spawner.TimeThreshold = 0.65f;
            } else if (Level == 7) {
                Spawner.TimeThreshold = 0.6f;
            } else if (Level == 6) {
                Spawner.TimeThreshold = 0.5f;
            } else if (Level == 5) {
                Spawner.TimeThreshold = 0.4f;
            } else if (Level == 4) {
                Spawner.TimeThreshold = 0.3f;
            } else if (Level == 3) {
                Spawner.TimeThreshold = 0.2f;
            } else if (Level == 2) {
                Spawner.TimeThreshold = 0.15f;
            } else if (Level == 1) {
                Spawner.TimeThreshold = 0.1f;
            } else if (Level == 0) {
                Spawner.TimeThreshold = 0.1f;
            }
        } 
        TimeThresholdCheck.text = "Spawner: " + Spawner.TimeThreshold.ToString ();

}

}