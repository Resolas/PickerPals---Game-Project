using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float forwardSpeed;
    public float sideSpeed;

    private Rigidbody myRB;

    [Header("Settings")]

    private float horz;
    private float jump;
    public float jumpPower;
    public bool onGround;
    public float groundRayDist = 2;



    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovementControl();

        

    }

    private void Update()
    {
        if (/*Input.GetAxis("Jump") != 0 &&*/ onGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRB.AddRelativeForce(transform.up * jumpPower, ForceMode.Impulse);
        }
    }

    void GroundChecker()
    {

        Debug.DrawLine(transform.position,transform.position + new Vector3(0, -groundRayDist, 0),Color.green);

        if (Physics.Raycast(transform.position, Vector3.down, groundRayDist))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }


    }

    public void MovementControl()
    {
        horz = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        Debug.Log("Horz = " + horz);
        Debug.Log("Jump =" + jump);


        GroundChecker();

        myRB.AddRelativeForce(transform.forward * forwardSpeed - myRB.velocity);

        myRB.AddRelativeForce(transform.right * sideSpeed * horz - myRB.velocity, ForceMode.Force);


    }


    private void OnDrawGizmos()
    {
        


    }

}
