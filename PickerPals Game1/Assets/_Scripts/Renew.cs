using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        getmyObItemGen = GetComponent<ObstacleItemGeneration>();
    }

    private void Update()
    {

        if (transform.position.z < 0)
        {
            Debug.Log("TEST");
            RenewTrack();
        }

    }




    // Renew Track Variables

    public TrackGenerator getTrackLength;
    public ObstacleItemGeneration getmyObItemGen;
    public float rePos = 25.25f;


    void RenewTrack()
    {
        if (getmyObItemGen != null) getmyObItemGen.SpawnNew();


        float newPos = rePos * getTrackLength.TrackLength;

        transform.Translate(new Vector3(0, -newPos,0));

    }



}
