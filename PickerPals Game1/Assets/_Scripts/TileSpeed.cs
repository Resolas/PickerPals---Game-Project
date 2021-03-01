using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpeed : MonoBehaviour
{
    
    public float mySpeed;

    public bool normalForward;

    // Update is called once per frame
    void Update()
    {
        mySpeed = GameStats.Globalspeed;

        if (normalForward != true)
        {
            transform.Translate(Vector3.up * mySpeed * Time.deltaTime);    // its up because its moving by localspace :L
        }
        else
        {
            transform.Translate(Vector3.forward * -mySpeed * Time.deltaTime);
        }
        
    }
}
