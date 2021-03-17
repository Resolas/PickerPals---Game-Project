using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour      // All the interactions needed to navigate the game menu
{
    // For scoring, game objectives and hidden game items
    public static float Globalspeed = 0;

    public float startSpeed = 10;
    public float rampUp = 0.2f;

    public float maxSpeed = 40;
    private bool inPlay = false;



    public int quota;
    public static int myCurScore;
    public int[] myLevelHighScores;
    public static int myCurTime;
    public int[] myLevelHighTimes;
    public bool[] levelsUnlocked; // for the buttons of levels to turn on or off
    public string[] levelNames;
    public int curLevelId;      // Set in DisplayLevelStats

    public Text displayScore;

    public GameObject myRunnerGUI;
    public GameObject myMenuGUI;
    public GameObject myDisplayStatsGUI;

 //   public GameObject getPlayer;
    public Button myLeftButton;
    public Button myRightButton;


    private static bool levelEnd = false;

    // Start is called before the first frame update
    void Start()
    {

     //   ActivatePlayer(false);

    }

    private void FixedUpdate()
    {

        if (inPlay == true && Globalspeed < maxSpeed)
        {
            Debug.Log(Globalspeed);
            Globalspeed += rampUp * Time.deltaTime;

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (displayScore != null)
        {
            displayScore.text = myCurScore.ToString();

        }

        

    }

    IEnumerator StartDelay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            inPlay = true;
            Globalspeed = startSpeed;
            GetNewRunner();
            //    ActivatePlayer(true);
            //    FindPlayerObject();
            Debug.Log("TESTCO");
            //   StopCoroutine(StartDelay(1));
            yield break;

        }

    }
    /*
    void ActivatePlayer(bool isTrue)
    {

        getPlayer.SetActive(isTrue);


    }
    */

    public void SetGlobalSpeed()    // Sets Speed after generating
    {

        StartCoroutine(StartDelay(1));

    }

    public void ResetSpeed()    // turns to zero when level ends
    {

        Globalspeed = 0;

    }

    public void GetNewRunner()
    {

        myRunnerGUI = null;
        displayScore = null;
        myLeftButton = null;
        myRightButton = null;




        myRunnerGUI = GameObject.Find("RunnerCanvas");
        displayScore = GameObject.Find("Score").GetComponent<Text>();
        myLeftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        myRightButton = GameObject.Find("RightButton").GetComponent<Button>();

    }

    public void ActivateMenu(bool isOn)
    {

        myMenuGUI.SetActive(isOn);
    }

    public void FinishGame()       // Ends the game from whatever happens e.g. winning or losing, sets the high scores for THAT level
    {

        inPlay = false;

        // Update Scores

        if (myLevelHighScores[curLevelId] < myCurScore)
        myLevelHighScores[curLevelId] = myCurScore;

        if (myLevelHighTimes[curLevelId] < myCurTime)
        myLevelHighTimes[curLevelId] = myCurTime;





    }

}
