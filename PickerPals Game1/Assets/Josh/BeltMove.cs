using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour
{
    public float speed;

    public bool onBelt;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (onBelt)
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
