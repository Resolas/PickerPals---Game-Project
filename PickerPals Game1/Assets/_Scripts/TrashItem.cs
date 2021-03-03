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

    [Header("Settings")]
    public bool useCubeCollider = false;
    public bool useCubeColliderRB = false;

    MeshFilter myFilter;
    MeshRenderer myRenderer;

    [SerializeField] private bool setTrig = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<MeshFilter>() != null)
        myFilter = GetComponent<MeshFilter>();

        if (GetComponent<MeshRenderer>() != null)
        myRenderer = GetComponent<MeshRenderer>();

        copyData();

        useDataModel();
    }

    void copyData() // Takes info from TrashData
    {
        if (myData != null)
        {
            trashTypeId = myData.trashType;

            int rng = Random.Range(0, myData.models.Length);
            chosenModel = myData.models[rng];

            myPoints = myData.points;
        }
      

    }

    void useDataModel()
    {

        if (gameObject.GetComponent<Rigidbody>() == true)
        {
            setTrig = false;
        }

        if (gameObject.GetComponent<MeshCollider>() == false && useCubeCollider != true && chosenModel.GetComponent<MeshFilter>().sharedMesh != null)
        {
            var newMCol = gameObject.AddComponent<MeshCollider>();

            newMCol.convex = true;
            newMCol.isTrigger = setTrig;

            Destroy(gameObject.GetComponent<BoxCollider>());
        }
        else if (gameObject.GetComponent<BoxCollider>() == false && useCubeCollider != false || chosenModel.GetComponent<MeshFilter>().sharedMesh == null)
        {

            var newCCol = gameObject.AddComponent<BoxCollider>();

            newCCol.isTrigger = setTrig;

        }

        if (gameObject.GetComponent<MeshFilter>() != false && gameObject.GetComponent<MeshRenderer>() != false)
        {

            myFilter.sharedMesh = chosenModel.GetComponent<MeshFilter>().sharedMesh;
            myRenderer.sharedMaterials = chosenModel.GetComponent<MeshRenderer>().sharedMaterials;
        }
        

    }

    
    
}
