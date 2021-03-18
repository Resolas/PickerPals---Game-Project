using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashHitGoal : MonoBehaviour
{

    public byte containerId;         // the type of trash    METAL = 0, GLASS = 1, PLASTIC = 2, PAPER&CARDBOARD = 3, FOOD = 4



    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Item"))
        {

            var getTrashId = other.GetComponent<TrashItem>().trashTypeId;

            if (containerId == getTrashId)
            {

                // do all the good stuff


                Destroy(other);

            }
            else if (containerId != getTrashId)
            {

                // do all the bad stuff


                Destroy(other);

            }

        }



    }




}
