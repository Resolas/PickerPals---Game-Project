using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashColSys : MonoBehaviour    // Trash Collection // Desc for every trash item collected its data will gathered and added to a list, and will reappear here
{

    // TrashData (ScriptableObject) -> TrashItem (Prefab/Object in runner) -> TrashColSys (System) -> TrashRB (Object recreated with data in sorting game)

    public List<TrashItem> collectedTrash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
