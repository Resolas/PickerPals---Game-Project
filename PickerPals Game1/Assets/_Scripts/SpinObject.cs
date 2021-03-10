using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{

    public float rotSpeedX = 5f;
    public float rotSpeedY = 5f;
    public float rotSpeedZ = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotSpeedX * Time.deltaTime,rotSpeedY * Time.deltaTime,rotSpeedZ * Time.deltaTime);
    }
}
