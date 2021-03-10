using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiModelVer : MonoBehaviour      // For items made up multiple model pieces
{

    public GameObject myObject;

    public void SpawnModels()
    {

        var myObj = Instantiate(myObject,transform.position,Quaternion.identity);

        myObj.transform.SetParent(gameObject.transform);
    }


}
