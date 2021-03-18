using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{

    public TrashData myData;

    [Header("Trash Settings")]
    public byte trashTypeId;     // the type of trash    METAL = 0, GLASS = 1, PLASTIC = 2, PAPER&CARDBOARD = 3, FOOD = 4

    public GameObject myPrefab; // REFERENCE ITSELF
    public GameObject chosenModel; // OBSOLETE
    public int myPoints;

    [Header("Collider Settings")]
    public bool useMeshColliderRB = false;
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

        RandomizeRotation();

    //    copyData();

    //    useDataModel();
    }

    void RandomizeRotation()
    {
        var rngX = Random.Range(0,360);
        var rngY = Random.Range(0,360);
        var rngZ = Random.Range(0,360);

        transform.Rotate(rngX, rngY, rngZ);
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
    /*
    void useDataModel()
    {

        if (gameObject.GetComponent<Rigidbody>() == true)
        {
            setTrig = false;
        }

        if (gameObject.GetComponent<MeshCollider>() == false && useCubeCollider != true )//   && chosenModel.GetComponent<MeshFilter>().sharedMesh != null
        {
            var newMCol = gameObject.AddComponent<MeshCollider>();

            newMCol.convex = true;
            newMCol.isTrigger = setTrig;

            Destroy(gameObject.GetComponent<BoxCollider>());
        }
        else if (gameObject.GetComponent<BoxCollider>() == false && useCubeCollider != false )//  || chosenModel.GetComponent<MeshFilter>().sharedMesh == null
        {

            var newCCol = gameObject.AddComponent<BoxCollider>();

            newCCol.isTrigger = setTrig;

        }

        if (chosenModel.GetComponent<MeshFilter>() != false && chosenModel.GetComponent<MeshRenderer>() != false)
        {

            myFilter.sharedMesh = chosenModel.GetComponent<MeshFilter>().sharedMesh;
            myRenderer.sharedMaterials = chosenModel.GetComponent<MeshRenderer>().sharedMaterials;
        }
        else
        {

            var getRep = chosenModel.GetComponent<MultiModelVer>();

            getRep.SpawnModels();

        }
        

    }

    */
    
}
