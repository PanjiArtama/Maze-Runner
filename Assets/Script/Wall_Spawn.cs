using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Spawn : MonoBehaviour
{
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn 10 Wall
        for(int i=0; i<10; i++)
        {
            Instantiate(wall, new Vector3(Random.Range(8, 85), 12, 10 + (i * 5.5f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
