using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOnLoad : MonoBehaviour     // Prevents the object from being destroyed on loadscene
{
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);

    }

}
