using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }
    private Rigidbody myRB;
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {

        myRB.velocity = transform.forward * speed;

    }
}
