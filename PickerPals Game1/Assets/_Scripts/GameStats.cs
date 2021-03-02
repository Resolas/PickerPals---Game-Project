using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    // For scoring, game objectives and hidden game items
    public static float Globalspeed = 0;
    public float setSpeed = 10;
    public int quota;
    public GameObject[] levelsUnlocked; // for the buttons of levels to turn on or off



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay(1));
    }

    // Update is called once per frame
    void Update()
    {
        
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
