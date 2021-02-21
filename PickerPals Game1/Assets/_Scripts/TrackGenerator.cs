using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    // Basically a for loop that is 'passed' over to each new object iteration

    [Header("Track Settings")]
    public TrackTypeGenTable getGenTable;

    public GameObject startTrack;   //  Standard Track that is generated (The 3 points)
    public GameObject firstTrackType;   // makes sure that the first track will be this type

    public int TrackLength;                // Set value and then it will be passed over to new tracks
    [SerializeField]
    private int curTrackNum = 0;               // Current value of the track

    public Transform spawnPoint;                       // position to spawn track type
    public Transform endSpawnPoint;                         // position to spawn new track

    [Header("Branching Path Settings")]

    public GameObject splitTrack;
    public int spawnChance = 10;
    public int spawnMargin = 10;    // mininum distance from the start before splitting
    [SerializeField]
    private bool isSplit = false;
    private bool isLeft = false;

    public Transform[] directions;

    [Header("Objective Item Settings")]
    public GameObject myItem;
    public int[] spawnAt = new int[5];


    // Start is called before the first frame update
    void Start()    
    {

        TrackGeneration();


    }

    void TrackGeneration()
    {
    //    getGenTable = GameObject.Find("TableHolder").GetComponent<TrackTypeGenTable>();

        if (curTrackNum == 0)
        {
            Instantiate(firstTrackType, spawnPoint.position, spawnPoint.rotation);  // Model Spawner
            curTrackNum++;
            GameObject myNewTrack = Instantiate(startTrack, endSpawnPoint.position, endSpawnPoint.rotation);    // New Track Spawner
            myNewTrack.GetComponent<TrackGenerator>().TrackLength = TrackLength;
            myNewTrack.GetComponent<TrackGenerator>().curTrackNum = curTrackNum++;

        }
        else if (curTrackNum != 0 && curTrackNum < TrackLength)
        {
        //    int splitRng = Random.Range(0, 100);

        //    if (splitRng > spawnChance && curTrackNum > spawnMargin)
          //  {
            //    int rngDir = Random.Range(0, 2);



           // }


            int rng = Random.Range(0, getGenTable.myTrackTypes.Length);

            Instantiate(getGenTable.myTrackTypes[rng], spawnPoint.position, spawnPoint.rotation);   // Model Spawner
            curTrackNum++;
            GameObject myNewTrack = Instantiate(startTrack, endSpawnPoint.position, endSpawnPoint.rotation);    // New Track Spawner
            myNewTrack.GetComponent<TrackGenerator>().TrackLength = TrackLength;
            myNewTrack.GetComponent<TrackGenerator>().curTrackNum = curTrackNum++;


            SpawnItems();

        }


    }


    void SpawnItems()
    {


        for (int i = 0; i < spawnAt.Length; i++)
        {

            if (curTrackNum == spawnAt[i])  // if its equals spawn an item
            {
                Instantiate(myItem, spawnPoint.position + new Vector3(0,10,0),Quaternion.identity);
            }

        }


    }



}
