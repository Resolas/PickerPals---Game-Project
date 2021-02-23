using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{

    public TrashData myData;

    [Header("Variables modded by TrashData")]
    public byte trashTypeId;
    public GameObject chosenModel;
    public int myPoints;


    // Start is called before the first frame update
    void Start()
    {


        copyData();


    }

    void copyData()
    {
        trashTypeId = myData.trashType;

        int rng = Random.Range(0,myData.models.Length);
        chosenModel = myData.models[rng];

        myPoints = myData.points;



    }

    
    
}
