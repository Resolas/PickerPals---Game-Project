using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoad : MonoBehaviour      // This is used when at the very beginning of loading the app to prevent duplicate static objects such as SystemHolder
{
    // Start is called before the first frame update
    void Start()
    {

        SceneManager.LoadScene("MenuScene");

    }

}
