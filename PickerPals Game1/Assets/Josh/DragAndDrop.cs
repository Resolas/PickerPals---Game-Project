using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //RigidBody
    public Rigidbody rb;
    
    // Z coordinate
    public float distanceToScreen;
    public float zoom = 0;
    
    // Movement
    public Vector3 targetPos;
    public float speed = 4;
    
    // Select object
    public bool selected = false;
    
    // Throw object
    public Vector3 previousGrabPosition;
    public float throwSpeed;
    public float throwClamp;

    public BeltMove beltMoveScript;
    
    void Start()
    {
        // Find RigidBody
        rb = GetComponent<Rigidbody>();

        // Find BeltMove
        beltMoveScript = GetComponent<BeltMove>();

    }

    void Update()
    {
        // Find mouse coordinates
        // Z
        distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // X, Y
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zoom));//distanceToScreen + zoom));
    }
    
    void OnMouseDrag()
    {
        // Select object
        selected = true;
        beltMoveScript.onBelt = false;
    }
    private void OnMouseUp()
    {
        selected = false;
        rb.constraints = RigidbodyConstraints.None;
        Vector3 throwVector = transform.position - previousGrabPosition;
        throwSpeed = throwVector.magnitude / Time.deltaTime;
        Vector3 throwVelocity = throwSpeed * throwVector.normalized;
        //rb.velocity = throwVelocity/2;

        var VelX = Mathf.Clamp(throwVelocity.x, -throwClamp, throwClamp);
        var VelY = Mathf.Clamp(throwVelocity.y, -throwClamp, throwClamp);
        
        rb.velocity = new Vector3(VelX/2, VelY, 5);
        //Debug.Log(new Vector3(VelX, VelY, 5));
    }
    
    void FixedUpdate()
    {
        if(selected)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Turn off gravity on selected object
            rb.useGravity = false;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Lock unintended rotation
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            rb.velocity = new Vector3(0, 0, 0);
            previousGrabPosition = transform.position;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Move object to mouse position
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        else
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Turn gravity back on
            rb.useGravity = true;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
