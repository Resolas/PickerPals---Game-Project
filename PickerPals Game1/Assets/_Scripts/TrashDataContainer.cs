using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TrashContainer", order = 5)]
public class TrashDataContainer : ScriptableObject  // Contains all the data from the TrashColSys
{
    
        public List<GameObject> myTrashList = new List<GameObject>();
}
