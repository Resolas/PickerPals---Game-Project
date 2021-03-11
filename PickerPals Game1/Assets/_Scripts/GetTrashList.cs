using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrashList : MonoBehaviour       // When loaded to sorting scene find TrashList and Start it up
{

    private GameObject getTrashList;

    private void Start()
    {

        StartupList();

    }

    void StartupList()
    {
        getTrashList = GameObject.Find("TrashList");

        var myTrashList = getTrashList.GetComponent<TrashColSys>();

        myTrashList.getSpawnPoint();

    }


}
