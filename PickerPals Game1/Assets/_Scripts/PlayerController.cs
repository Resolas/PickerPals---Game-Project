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

    private bool moveLeft;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //    MovementControl("NONE");
        MovementControlKeys();
        myRB.AddRelativeForce(transform.forward * forwardSpeed - myRB.velocity);
        GroundChecker();


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

    public void MovementControlKeys()
    {
        horz = Input.GetAxis("Horizontal");
        //       jump = Input.GetAxis("Jump");

        Debug.Log("Horz = " + horz);
        Debug.Log("Jump =" + jump);



        //       myRB.velocity = new Vector3(myRB.velocity.x, myRB.velocity.y, 20);
        Debug.Log(myRB.velocity);

        myRB.AddRelativeForce(transform.right * sideSpeed * horz - myRB.velocity, ForceMode.Force);
    }

    public void MovementControlTouch(string _input)   // LEFT RIGHT NONE
    {
        string myLInput = _input;

        if (_input == "LEFT")
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
        if (_input == "RIGHT")
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        
        if (moveLeft == true) myRB.AddRelativeForce(transform.right * sideSpeed * -1 - myRB.velocity, ForceMode.Force);

        if (moveRight == true) myRB.AddRelativeForce(transform.right * sideSpeed * 1 - myRB.velocity, ForceMode.Force);

        #region Switch Code
        /*
        switch (_input)
        {

            case "NONE":
                horz = Input.GetAxis("Horizontal");
         //       jump = Input.GetAxis("Jump");

                Debug.Log("Horz = " + horz);
                Debug.Log("Jump =" + jump);


                  
         //       myRB.velocity = new Vector3(myRB.velocity.x, myRB.velocity.y, 20);
                Debug.Log(myRB.velocity);

                myRB.AddRelativeForce(transform.right * sideSpeed * horz - myRB.velocity, ForceMode.Force);

                break;

            case "LEFT":

                myRB.AddRelativeForce(transform.right * sideSpeed * -1 - myRB.velocity, ForceMode.Force);
                break;

            case "RIGHT":

                myRB.AddRelativeForce(transform.right * sideSpeed * 1 - myRB.velocity, ForceMode.Force);
                break;

        }
        */
        #endregion

    }

    private void OnTriggerStay(Collider other)
    {


        if (other.CompareTag("Item"))
        {

            TrashItem getTrashId = other.GetComponent<TrashItem>(); // upon collection gets the trash id and send it over to the system VVV
            TrashColSys getSys = GameObject.FindObjectOfType<TrashColSys>();

            getSys.getTrashId(getTrashId.trashTypeId,getTrashId.chosenModel,getTrashId.myPoints);                   //          <<<<<<<<<<<

            Destroy(other.gameObject);


        }


    }

    
    

}
