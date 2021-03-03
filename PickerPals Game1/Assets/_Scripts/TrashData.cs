using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TrashData", order = 4)]
public class TrashData : ScriptableObject  // Describes what type of trash it is :I
{

    public byte trashType;      // the type of trash    METAL = 0, GLASS = 1, PLASTIC = 2, PAPER&CARDBOARD = 3, FOOD = 4

    public GameObject[] models; // put models in that are the same type of trash recycleable, non - recycleable etc...

    public int points;

    

}
