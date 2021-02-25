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

    public void getTrashId(byte _trashType, GameObject _model, int _points)
    {

        GameObject newTrash = Instantiate(objectData,transform.position,Quaternion.identity);
        newTrash.transform.SetParent(gameObject.transform);

        var getTrashComp = newTrash.GetComponent<TrashItem>();
        

        getTrashComp.trashTypeId = _trashType;
        getTrashComp.chosenModel = _model;
        getTrashComp.myPoints = _points;
        
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


                GameObject newTrashRB = Instantiate(TrashRBTemplate, mySpawnPoint.transform.position, transform.rotation);
                TrashItem newTrashData = newTrashRB.GetComponent<TrashItem>();

                newTrashData.myPoints = collectedTrash[rng].GetComponent<TrashItem>().myPoints;
                newTrashData.chosenModel = collectedTrash[rng].GetComponent<TrashItem>().chosenModel;
                newTrashData.trashTypeId = collectedTrash[rng].GetComponent<TrashItem>().trashTypeId;

                newTrashRB.GetComponent<MeshRenderer>().sharedMaterials = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshRenderer>().sharedMaterials;
                newTrashRB.GetComponent<MeshFilter>().sharedMesh = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshFilter>().sharedMesh;
                newTrashRB.GetComponent<MeshCollider>().sharedMesh = collectedTrash[rng].GetComponent<TrashItem>().chosenModel.GetComponent<MeshCollider>().sharedMesh;

                Destroy(collectedTrash[rng].gameObject);
                collectedTrash.RemoveAt(rng);
            }

            yield return new WaitForSeconds(waitTime);
        }


    }



    private void OnApplicationQuit()
    {

     //   myTrashContainer.myTrashList = null;

    }

    

}
