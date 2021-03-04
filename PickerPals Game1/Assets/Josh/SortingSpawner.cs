using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSpawner : MonoBehaviour
{
    public float spawnTimer;

    public GameObject[] litter;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLitter(spawnTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator SpawnLitter(float waitTime)
    {
        var randomNo = Random.Range(0, litter.Length);
        var rotation = Quaternion.Euler(-90, 0, 0);
        Instantiate(litter[randomNo], transform.position, rotation);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnLitter(spawnTimer));
    }
}
