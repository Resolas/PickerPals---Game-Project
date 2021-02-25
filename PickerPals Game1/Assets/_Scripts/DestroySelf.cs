using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }

    }

    


}
