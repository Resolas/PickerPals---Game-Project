using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpeed : MonoBehaviour
{
    public float startDelay;
    private float mySpeed = 0;
  //  private int speedMult = 0;
    public bool normalForward;

    

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
