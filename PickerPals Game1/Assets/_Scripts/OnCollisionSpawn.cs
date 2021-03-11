using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSpawn : MonoBehaviour
{

    public GameObject myEffect;

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Instantiate(myEffect,transform.position,Quaternion.identity);

            if (gameObject.CompareTag("Obstacle")) other.GetComponent<PlayerController>().health--;

            Destroy(gameObject);

        }

    }

}
