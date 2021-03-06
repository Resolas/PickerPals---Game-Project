﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashColSys : MonoBehaviour    // Trash Collection // Desc for every trash item collected its data will gathered and added to a list, and will reappear here
{

    // TrashData (ScriptableObject) -> TrashItem (Prefab/Object in runner) -> TrashColSys (System) -> TrashRB (Object recreated with data in sorting game)

    public List<GameObject> collectedTrash = new List<GameObject>();
 //   public TrashDataContainer myTrashContainer;

    public GameObject objectData;
    public GameObject mySpawnPoint;
  //  public GameObject TrashRBTemplate;

    //  public GameObject emptyObject;

    private void Start()
    {
    //    getSpawnPoint();
    }

    public void getTrashId(byte _trashType,GameObject _prefab , GameObject _model, int _points)
    {

        GameObject newTrash = Instantiate(_prefab,transform.position,Quaternion.identity);       
        newTrash.transform.SetParent(gameObject.transform);
        Destroy(newTrash.GetComponent<SpinObject>());       // Spinning unneeded in while stored

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

    [Header("RBSpawner Settings")]
    public float beltSpeed = -1;
    public bool checkOnBelt = true;
    public float dragHoldDist = 4;
    public float setThrowClamp = 5;
    public float setThrowSpeed = 0;

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
                newTrashRB.AddComponent<BeltMove>();
                newTrashRB.AddComponent<DragAndDrop>();

                // Destroy/Remove Components for use in sorting stage
              //  Destroy(newTrashRB.GetComponent<SpinObject>());
                

                // sets the new components values

                var setBelt = newTrashRB.GetComponent<BeltMove>();
                var setDrag = newTrashRB.GetComponent<DragAndDrop>();

                setBelt.speed = beltSpeed;
                setBelt.onBelt = checkOnBelt;
                setDrag.zoom = dragHoldDist;
                setDrag.throwClamp = setThrowClamp;
                setDrag.throwSpeed = setThrowSpeed;

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
