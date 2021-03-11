using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnQuit : MonoBehaviour  // put this on things that instantiates on destroy
{


    private void OnApplicationQuit()
    {

        Destroy(gameObject);

    }


}
