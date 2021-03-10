using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItemGeneration : MonoBehaviour     // Generations Obstacles AND Items (Trash) on the tracks to pick up and avoid
{

    public ItemObsTable myTable;

 //   public Transform[] myItemPoints;         // Spawn pos exclusively for items (trash :I)   
 //   public Transform[] myObstaclePoints;            // Spawn pos for obstacles
 //   public Transform[] myMixedPoints;                       // Spawn pos for both

    [Header("GridSpawn Settings")]

    public int[] row = new int[3];
    public int[] col = new int[3];
    public Transform[,] gridSys = new Transform[3, 3];

    public Transform firstPoint;        // the starting position to create the grid of points and will not count towards to the array
    public GameObject spawnPoint;
    public Vector3 spacing = new Vector3();

    int obstaclelimit = 2;
    int curObNum = 0;
    public List<GameObject> currentObjects;

    // Start is called before the first frame update
    void Start()
    {
        gridSys = new Transform[row.Length, col.Length];

        

        for (int i = 0; i < row.Length; i++)
        {

            for (int j = 0; j < col.Length; j++)
            {

                


                GameObject newPos = Instantiate(spawnPoint,firstPoint.transform.position + new Vector3(spacing.x * j, 0, spacing.z * i),Quaternion.identity);

                newPos.transform.SetParent(transform);

                gridSys[i, j] = newPos.transform;
                

            }


        }

        SpawnNew();
        #region Unused
        /*
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

    */
        #endregion
    }


    public void SpawnNew()
    {

        if (currentObjects != null)
        {

            for (int i = 0; i < currentObjects.Count; i++)
            {

                Destroy(currentObjects[i]);
            //    currentObjects.RemoveAt(i);

            }
            currentObjects = new List<GameObject>();

        }

        for (int i = 0; i < row.Length; i++)
        {
            curObNum = 0;

            for (int j = 0; j < col.Length; j++)
            {

               int rng = Random.Range(0,3); //  0 = item, 1 = obstacle 2 = nothing


                if (rng == 0)
                {
                    int itemRng = Random.Range(0, myTable.items.Length);

                 var newItem = Instantiate(myTable.items[itemRng],gridSys[i,j].transform.position, Quaternion.identity);
                    newItem.transform.SetParent(transform);
                    newItem.tag = "Item";
                    currentObjects.Add(newItem);

                }
                else if (rng == 1 && curObNum < obstaclelimit)
                {

                    int obstacleRng = Random.Range(0,myTable.obstacles.Length);

                  var newObstacle = Instantiate(myTable.obstacles[obstacleRng],gridSys[i,j].transform.position + new Vector3(0,-1,0),Quaternion.Euler(-90,0,0));
                    newObstacle.transform.SetParent(transform);
                    newObstacle.tag = "Obstacle";
                    currentObjects.Add(newObstacle);

                    curObNum++;

                }
                else if (rng == 2 || curObNum <= obstaclelimit)
                {
                    continue;
                }
                


            }


        }



    }

    private void OnDrawGizmos()
    {
        if (firstPoint == null) return;

        for (int i = 0; i < row.Length; i++)
        {

            for (int j = 0; j < col.Length; j++)
            {


                Gizmos.color = new Color(0.3f * j,0.1f,0.8f);
                Gizmos.DrawSphere(firstPoint.transform.position + new Vector3(spacing.x * i, 0, spacing.z * j), 0.5f);

            }

        }

        
           
    }

}
