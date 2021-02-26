using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItemGeneration : MonoBehaviour     // Generations Obstacles AND Items (Trash) on the tracks to pick up and avoid
{

    public ItemObsTable myTable;

    public Transform[] myItemPoints;         // Spawn pos exclusively for items (trash :I)   
    public Transform[] myObstaclePoints;            // Spawn pos for obstacles
    public Transform[] myMixedPoints;                       // Spawn pos for both

    // Start is called before the first frame update
    void Start()
    {

        if (myItemPoints != null)
        {
            for (int i = 0; i < myItemPoints.Length; i++)
            {
                int rng = Random.Range(0,myTable.items.Length);

             var newObject = Instantiate(myTable.items[rng],myItemPoints[i].transform.position,Quaternion.identity);

                newObject.transform.SetParent(gameObject.transform);
            }

        }

        if (myObstaclePoints != null)
        {
            for (int i = 0; i < myObstaclePoints.Length; i++)
            {
                int rng = Random.Range(0, myTable.items.Length);

               var newObject = Instantiate(myTable.items[rng], myObstaclePoints[i].transform.position, Quaternion.identity);

                newObject.transform.SetParent(gameObject.transform);
            }

        }

        if (myMixedPoints != null)
        {
            for (int i = 0; i < myMixedPoints.Length; i++)
            {
                int rng = Random.Range(0, myTable.items.Length);

               var newObject = Instantiate(myTable.items[rng], myMixedPoints[i].transform.position, Quaternion.identity);

                newObject.transform.SetParent(gameObject.transform);
            }

        }



    }

    
}
