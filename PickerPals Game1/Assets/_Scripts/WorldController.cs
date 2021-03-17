using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour // World Rotator
{

    public GameObject getWorld;
    public float rotSpeed = 10;

    public float sensitivity = 5;
    private Vector3 mouseRef;
    private Vector3 mouseOffset;
    private Vector3 _rot;
    private bool _isRot;


//    public GameObject[] myLevels;


    private void Start()
    {
        
        _rot = Vector3.zero;
        
    }

    private void Update()
    {

        RotateWorld();

        
    }

    void RotateWorld()
    {
        // key ver

        float horz = Input.GetAxis("HorizontalMenu");

        getWorld.transform.Rotate(0,horz * rotSpeed * Time.deltaTime,0);


        // drag ver

        if (_isRot)
        {

            mouseOffset = (Input.mousePosition - mouseRef);

            _rot.y = -(mouseOffset.x + mouseOffset.y) * sensitivity;

            getWorld.transform.Rotate(_rot);

            mouseRef = Input.mousePosition;
            Debug.Log(_isRot + " " + _rot);
        }

    }

    private void OnMouseDown()
    {
        _isRot = true;
    //    Debug.Log("TEST");
        mouseRef = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _isRot = false;
    }





}
