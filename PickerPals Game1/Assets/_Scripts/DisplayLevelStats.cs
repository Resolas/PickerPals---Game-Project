using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevelStats : MonoBehaviour  // Gets Info from GameStats and sends it to LevelStatsUI and is to be put on objects on world to be clicked on
{
    // Start is called before the first frame update
    void Start()
    {
        getGameStats = GameObject.Find("SystemHolder");

        displayStats = GameObject.Find("DisplayLevelStatsUI");
    }

    public string myLevelName;
    public int levelNumber = 0;

    public GameObject getGameStats;
    public GameObject displayStats;


    private void OnMouseDown()
    {

        var findMyLevel = getGameStats.GetComponent<GameStats>().levelsUnlocked;

        var getStatsUI = displayStats.GetComponent<LevelStatsUI>();

        var getLevelStats = getGameStats.GetComponent<GameStats>();

        for (int i = 0; i < findMyLevel.Length; i++)
        {

            if (levelNumber == i && findMyLevel[i] != false)
            {
                Debug.Log(i);
                //    getLevelStats(i);

                getStatsUI.displayHighScore = getLevelStats.myLevelHighScores[i];
                getStatsUI.displayHighTime = getLevelStats.myLevelHighTimes[i];
                getLevelStats.curLevelId = levelNumber;

                getStatsUI.selectedLevelName = myLevelName;
                getStatsUI.selectedLevelName = myLevelName;

            }
            else
            {
                Debug.Log("LOCKED!");
            }
        }


    }

    private void OnMouseOver()
    {
        
    }

    

    /*
    void getLevelStats(int _myLevel)
    {

        



    }
    */

}
