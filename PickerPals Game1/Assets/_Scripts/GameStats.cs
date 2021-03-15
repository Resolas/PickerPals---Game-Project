using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour      // All the interactions needed to navigate the game menu
{
    // For scoring, game objectives and hidden game items
    public static float Globalspeed = 0;
    public float setSpeed = 10;
    public int quota;
    public static int myCurScore;
    public int[] myLevelHighScores;
    public static int myCurTime;
    public int[] myLevelHighTimes;
    public bool[] levelsUnlocked; // for the buttons of levels to turn on or off
    public string[] levelNames;

    public Text displayScore;

    public GameObject myRunnerGUI;
    public GameObject myMenuGUI;
    public GameObject myDisplayStatsGUI;


    private static bool levelEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        displayScore.text = myCurScore.ToString();

    }

    IEnumerator StartDelay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Globalspeed = setSpeed;

            StopCoroutine(StartDelay(1));
        }

    }

    public void SetGlobalSpeed()
    {

        StartCoroutine(StartDelay(1));

    }

    public void ResetSpeed()
    {

        Globalspeed = 0;

    }

    public void ActivateRunner(bool isOn)
    {
        myRunnerGUI.SetActive(isOn);
    }

    public void ActivateMenu(bool isOn)
    {
        myMenuGUI.SetActive(isOn);
    }

}
