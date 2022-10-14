using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    List<Transform> ListBrick = new List<Transform>();
   
    private float unit = 2f;
    private void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        SpawnBrick();
    }

    private void SpawnBrick()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                Instantiate(brickPrefabs[Random.Range(0, brickPrefabs.Length)], new Vector3(i, 0, j) * unit, Quaternion.identity);

           }
        }
    }


  
}
