using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data",menuName = "ScriptableObjects/ItemObsTable",order = 3)]
public class ItemObsTable : ScriptableObject
{

    public GameObject[] items;

    public GameObject[] obstacles;

}
