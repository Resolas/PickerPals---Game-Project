using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    // For scoring, game objectives and hidden game items
    public static float Globalspeed = 0;
    public float setSpeed = 10;
    public int quota;
    public static int myScore;
    public static int myHighScore;
    public GameObject[] levelsUnlocked; // for the buttons of levels to turn on or off

    public Text displayScore;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay(1));
    }

    // Update is called once per frame
    void Update()
    {

        displayScore.text = myScore.ToString();

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
}
