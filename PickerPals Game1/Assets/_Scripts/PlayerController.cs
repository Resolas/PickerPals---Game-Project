using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int health = 5;
    public Text myText;

    public Transform[] lanePos = new Transform[3];
    public int curLane = 1;
    private int newLane;


    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {

        //    MovementControl("NONE");
        
        myRB.AddRelativeForce(transform.forward * forwardSpeed - myRB.velocity);
        GroundChecker();
        UIElements();

    }

    private void Update()
    {
        MovementControlKeys();
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

        if (Input.GetKeyDown(KeyCode.A) && curLane > 0)
        {
            curLane--;
        }

        if (Input.GetKeyDown(KeyCode.D) && curLane < lanePos.Length - 1)
        {
            curLane++;
        }

        transform.position = Vector3.MoveTowards(transform.position,lanePos[curLane].position,0.1f);



        #region UNUSED
        /*

        horz = Input.GetAxis("Horizontal");
        //       jump = Input.GetAxis("Jump");

        Debug.Log("Horz = " + horz);
        Debug.Log("Jump =" + jump);



        //       myRB.velocity = new Vector3(myRB.velocity.x, myRB.velocity.y, 20);
        Debug.Log(myRB.velocity);

        myRB.AddRelativeForce(transform.right * sideSpeed * horz - myRB.velocity, ForceMode.Force);



        // TouchMovement
        if (moveLeft == true) myRB.AddRelativeForce(transform.right * sideSpeed * -1 - myRB.velocity, ForceMode.Force);
        if (moveRight == true) myRB.AddRelativeForce(transform.right * sideSpeed * 1 - myRB.velocity, ForceMode.Force);

        */
        #endregion
    }

    public void MovementLaneControlTouch(int value)
    {

        if (value == -1 && curLane <= 0) return;
        if (value == 1 && curLane >= lanePos.Length - 1) return;

        curLane += value;

    }


    public void MovementControlTouchLeft(string _input)   // LEFT RIGHT BOTH
    {

        if (_input == "LEFT")
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

    }

    public void MovementControlTouchRight(string _input)
    {

        if (_input == "RIGHT")
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        

    }


    [Header("Pickup Settings")]
    public GameObject trashPickupEffect;
    public GameObject obstacleEffect;
 //   public GameObject powerPickupEffect;

    private void OnTriggerStay(Collider other)
    {


        if (other.CompareTag("Item"))
        {

            TrashItem getTrashId = other.GetComponent<TrashItem>();                 // upon collection gets the trash id and send it over to the system VVV
            TrashColSys getSys = GameObject.FindObjectOfType<TrashColSys>();

            getSys.getTrashId(getTrashId.trashTypeId,getTrashId.myPrefab,getTrashId.chosenModel,getTrashId.myPoints);                   //          <<<<<<<<<<<

            Instantiate(trashPickupEffect,other.transform.position,Quaternion.identity);

            Destroy(other.gameObject);


        }

        if (other.CompareTag("Obstacle"))
        {

            health--;

        //    Instantiate(obstacleEffect,gameObject.transform.position,Quaternion.identity);

            Destroy(other.gameObject);



        }


    }

    void UIElements()
    {

        myText.text = health.ToString();


    }
    

}
