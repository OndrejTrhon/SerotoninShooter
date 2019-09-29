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

    private int Day;
    public Text LevelText;
    public Text TimeText;
    public Text GameStateText;
    public Text TimeThresholdCheck;
    public GameObject LevelObject;
    public GameObject MessageDisplay;

    public GameObject EndScreen;
    public SpawnMovingTargets Spawner;



    // Start is called before the first frame update
    void Start()
    {
        Level = 12;
        Day = 1;
                            Debug.Log(Day); 
        Time = 0;
        GameState = 1;
        InvokeRepeating("Ticker", 1.0f, 1f);
        InvokeRepeating("Ticker_messages", 2.0f, 2f);
        InvokeRepeating("Clock", 1.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //This is where you take antidepressants, yay
     if (Input.GetKeyDown(KeyCode.E)) {
              TakeMedication();
     }

     if (Day == 8) {
         EndGame();
     }
          
    }

    //Clock only controls time

    void Clock() {
        if (Time <= 23) {
            Time = Time + 1;
        } else {
            Time = 0;
            Day = Day + 1;
                                Debug.Log(Day); 
        }

        //Debug.Log(Time);
        TimeText.text = "Time: " + Time.ToString ();
    
    }

    //Tick is the main fucntion which is updated every second, setting the difficulty of the game
    void Ticker()
    {
        UpdateDifficulty();
        LevelObserver();
              //Debug.Log(Level);
              GameStateText.text = "GameState: " + GameState.ToString ();
    }

      void Ticker_messages()
    {
        SetMessage();
    }

    //function taking care of checking the level of antidepressant
    void LevelObserver() {
        Level--;
        LevelText.text = "Level: " + Level.ToString ();
        LevelShow();
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


    void SetList(List<string> listvar) {
        var Message = MessageDisplay.GetComponent<TMPro.TextMeshProUGUI>();
        int index = Random.Range (0, listvar.Count);
        Message.text = listvar[index];
    }


    void SetMessage() {
    
        if (GameState == 1) {
            var list = new List<string>{"VIVID DREAMS (ALSO BAD ONES)","HARDER ORGASM","LOWER ANXIETY (BUT ALSO PLEASURE)","TINY TREMORS"};
            SetList(list);

        } else if (GameState == 2) {
            var list = new List<string>{"TINY TREMORS (AND HEAT)","RESTLESS LEGS","LITTLE HEADACHE"};
            SetList(list);
        } else if (GameState == 3) {
            var list = new List<string>{"TREMORS","HEADACHE","CONFUSION"};
            SetList(list);
        } else if (GameState == 4) {
            var list = new List<string>{"CONFUSION","BIG HEADACHE","HOW CAN I GET THE WOrk DONE?"};
            SetList(list);
        } else if (GameState == 5) {
            var list = new List<string>{"I FEEL LIKE A FEATHER","ANXIOUS?","TIRED"};
            SetList(list);
        } else if (GameState == 6) {
            var list = new List<string>{"LITTLE HEADACHE","ANXIOUS!","UNCLEAR CRAVING"};
            SetList(list);
        } else if (GameState == 7) {
            var list = new List<string>{"DAZED","HEADACHE","SHAKING WELL"};
            SetList(list);
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

    void DisableChildren(GameObject TargetParent, int LevelIndex) {   

        for (int a = 0; a < TargetParent.transform.childCount; a++)
            {
              TargetParent.transform.GetChild(a).gameObject.SetActive(false);
            }

        TargetParent.transform.GetChild(LevelIndex).gameObject.SetActive(true);

    }

    void LevelShow() {
            if (Level == 24) {    
                DisableChildren (LevelObject, 22);
            } else if (Level == 23) {
                DisableChildren (LevelObject, 22);
            } else if (Level == 22) {
                DisableChildren (LevelObject, 21);
            } else if (Level == 21) {
                DisableChildren (LevelObject, 20);
            } else if (Level == 20) {
                DisableChildren (LevelObject, 19);
            } else if (Level == 19) {
                DisableChildren (LevelObject, 18);
            } else if (Level == 18) {
                DisableChildren (LevelObject, 17);
            } else if (Level == 17) {
                DisableChildren (LevelObject, 16);
            } else if (Level == 16) {
                DisableChildren (LevelObject, 15);
            } else if (Level == 15) {
                DisableChildren (LevelObject, 14);
            } else if (Level == 14) {
                DisableChildren (LevelObject, 13);
            } else if (Level == 13) {
                DisableChildren (LevelObject, 12);
            } else if (Level == 12) {
                DisableChildren (LevelObject, 11);            
            } else if (Level == 11) {
                DisableChildren (LevelObject, 10);
            } else if (Level == 10) {
                DisableChildren (LevelObject, 9);
            } else if (Level == 9) {
                DisableChildren (LevelObject, 8);
            } else if (Level == 8) {
                DisableChildren (LevelObject, 7);
            } else if (Level == 7) {
                DisableChildren (LevelObject, 6);
            } else if (Level == 6) {
                DisableChildren (LevelObject, 5);
            } else if (Level == 5) {
                DisableChildren (LevelObject, 4);
            } else if (Level == 4) {
                DisableChildren (LevelObject, 3);
            } else if (Level == 3) {
                DisableChildren (LevelObject, 2);
            } else if (Level == 2) {
                DisableChildren (LevelObject, 1);
            } else if (Level == 1) {
                DisableChildren (LevelObject, 0);
            } else if (Level == 0) {
                DisableChildren (LevelObject, 0);
            }
    }

    void ShowMessage() {
        var Message = MessageDisplay.GetComponent<TMPro.TextMeshProUGUI>();
        Message.text = "TEST";   

    }

    void EndGame() {  
        EndScreen.gameObject.SetActive(true);
    }
}