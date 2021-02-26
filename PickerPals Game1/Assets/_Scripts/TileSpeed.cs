using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpeed : MonoBehaviour
{
    
    public float mySpeed;

    // Update is called once per frame
    void Update()
    {
        mySpeed = GameStats.Globalspeed;

        transform.Translate(Vector3.up * mySpeed * Time.deltaTime);    // its up because its moving by localspace :L
    }
}
