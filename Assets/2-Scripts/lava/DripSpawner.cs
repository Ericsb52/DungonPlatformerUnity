using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripSpawner : MonoBehaviour
{

    public GameObject dripPrefab;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnDrip()
    {
        GameObject drip = Instantiate(dripPrefab, spawnPoint);
        drip.transform.position = spawnPoint.position;
    }

}
