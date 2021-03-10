using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashColSys : MonoBehaviour    // Trash Collection // Desc for every trash item collected its data will gathered and added to a list, and will reappear here
{

    // TrashData (ScriptableObject) -> TrashItem (Prefab/Object in runner) -> TrashColSys (System) -> TrashRB (Object recreated with data in sorting game)

    public List<GameObject> collectedTrash = new List<GameObject>();
 //   public TrashDataContainer myTrashContainer;

    public GameObject objectData;
    public GameObject mySpawnPoint;
    public GameObject TrashRBTemplate;

    //  public GameObject emptyObject;

    private void Start()
    {
        getSpawnPoint();
    }

    public void getTrashId(byte _trashType,GameObject _prefab , GameObject _model, int _points)
    {

        GameObject newTrash = Instantiate(_prefab,transform.position,Quaternion.identity);       
        newTrash.transform.SetParent(gameObject.transform);

        var getTrashComp = newTrash.GetComponent<TrashItem>();
        

    //    getTrashComp.trashTypeId = _trashType;
    //    getTrashComp.myPrefab = _prefab;
    //    getTrashComp.chosenModel = _model;
    //    getTrashComp.myPoints = _points;
        
      //  myTrashContainer.myTrashList.Add(newTrash);
      //  Debug.Log("TEST");
         collectedTrash.Add(newTrash);

    }

    public void getSpawnPoint()
    {
        mySpawnPoint = GameObject.FindWithTag("Spawner");

        if (mySpawnPoint != null)
        {

            StartCoroutine(SpawnTrash(3));

        }


    }

    IEnumerator SpawnTrash(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (collectedTrash != null)
            {

                int rng = Random.Range(0, collectedTrash.Count); // Picks a Trash Data number

                GameObject newTrashRB = Instantiate(collectedTrash[rng], mySpawnPoint.transform.position, transform.rotation);
                var checkColSet = newTrashRB.GetComponent<TrashItem>();

                if (checkColSet.useCubeColliderRB && newTrashRB.GetComponent<BoxCollider>() != null) newTrashRB.GetComponent<BoxCollider>().isTrigger = false;

                if (checkColSet.useMeshColliderRB && newTrashRB.GetComponent<MeshCollider>() != null) newTrashRB.GetComponent<MeshCollider>().isTrigger = false;

                // Adds components to trash for use in sorting stage
                newTrashRB.AddComponent<Rigidbody>();
                newTrashRB.AddComponent<DragAndDrop>();
                newTrashRB.AddComponent<BeltMove>();

                

                Destroy(collectedTrash[rng].gameObject);        // Deletes that trash object
                collectedTrash.RemoveAt(rng);               // Clears Element of that trash

                #region unused
                /*
                int rng = Random.Range(0, collectedTrash.Count); // Picks a Trash Data number


                GameObject newTrashRB = Instantiate(TrashRBTemplate, mySpawnPoint.transform.position, transform.rotation);
                TrashItem newTrashData = newTrashRB.GetComponent<TrashItem>();

                // Trash Information        Copies the info to the RB version
                newTrashData.myPoints = collectedTrash[rng].GetComponent<TrashItem>().myPoints;
                newTrashData.chosenModel = collectedTrash[rng].GetComponent<TrashItem>().chosenModel;
                newTrashData.trashTypeId = collectedTrash[rng].GetComponent<TrashItem>().trashTypeId;

                // Colliders & Mesh         
                Vector3 getScale = collectedTrash[rng].transform.localScale;
                newTrashRB.transform.localScale = new Vector3(getScale.x,getScale.y,getScale.z);
                newTrashRB.GetComponent<MeshRenderer>().sharedMaterials = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshRenderer>().sharedMaterials;
                newTrashRB.GetComponent<MeshFilter>().sharedMesh = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshFilter>().sharedMesh;

              //  if ()

                newTrashRB.GetComponent<MeshCollider>().sharedMesh = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshCollider>().sharedMesh;

                Destroy(collectedTrash[rng].gameObject);
                collectedTrash.RemoveAt(rng);
                */
                #endregion
            }

            //    yield return new WaitForSeconds(waitTime);


        }


    }



    private void OnApplicationQuit()
    {

     //   myTrashContainer.myTrashList = null;

    }

    

}
