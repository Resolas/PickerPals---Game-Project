using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStatsUI : MonoBehaviour   // The Canvas That Displays The Info and Level Loader
{
    // Start is called before the first frame update
    void Start()
    {
        getGameStats = GameObject.Find("SystemHolder");
    }

    // Update is called once per frame
    void Update()
    {

        showLevelStats();

    }

    public GameObject getGameStats;

    public int displayHighScore = 0;
    public float displayTime = 0;
    public int displayTotalTrash = 0;

    public string selectedLevelName;

    public Text highScoreText;
    public Text timeText;
    public Text totalTrashText;
    public Text LevelNameText;

    public void loadLevel()
    {
        getGameStats.GetComponent<GameStats>().SetGlobalSpeed();



        SceneManager.LoadScene(selectedLevelName);

    }

    void showLevelStats()
    {

        highScoreText.text = displayHighScore.ToString();
        timeText.text = displayHighScore.ToString();
        totalTrashText.text = displayHighScore.ToString();
        LevelNameText.text = selectedLevelName;


    }


}
