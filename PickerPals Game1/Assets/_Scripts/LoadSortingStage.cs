using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSortingStage : MonoBehaviour       // Loads to the sorting stage when the runner section level ends
{
    // Start is called before the first frame update
    void Start()
    {
     //   SceneManager.LoadScene();
    }

    // Update is called once per frame
    void Update()
    {

        LoadTest();

    }

    void LoadTest()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            LoadSortingScene();

        }

    }

    void LoadSortingScene()
    {

        SceneManager.LoadScene("SortingLevel");


    }

    
}
