using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{

    [System.Serializable]
    public class SpawnedBricks
    {
        public int colorName;
        public Vector3 position;
        public bool removed;
    }

    public SpawnedBricks[] spawnedBricks;

    private Vector3 startPoint;
    private Vector3 position;

    private int length = 36;
    private int line = 6;
    private int xOrder = 0;

    private float zPosition;
    private float xPosition;


    public GameObject[] brickPrefabs;
    List<Transform> ListBrick = new List<Transform>();

     
    private void Start()
    {
        InvokeRepeating(nameof(GenerateRemovedBrick), 1, 5f);
        OnInit();
    }

    void OnInit()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;

        spawnedBricks = new SpawnedBricks[length];

        CreateBricks();
    }


    private void CreateBricks()
    {
        for (int i = 0; i < length; i++)
        {
            xOrder++;
            if (i % line == 0)
            {
                zPosition -= 1f;
                xOrder = 0;
                position = new Vector3(xPosition, startPoint.y, zPosition);
            }
            else
            {
                position = new Vector3(xPosition + xOrder, startPoint.y, zPosition);
            }

            Transform createdBrick = Instantiate(brickPrefabs[Random.Range(0, brickPrefabs.Length)], position, Quaternion.identity).transform;

            createdBrick.transform.SetParent(this.transform);
            createdBrick.GetComponent<Brick>().numberBrick = i;
            InsertIntoArray(createdBrick, (int)createdBrick.GetComponent<Brick>().brickColor, i);

        }
    }

    public void MakeRemoved(int brickNumber)
    {
        spawnedBricks[brickNumber].removed = true;
    }
    private void InsertIntoArray(Transform createdBrick, int colorName,int i)
    {
        var tmp = new SpawnedBricks();
        tmp.colorName = colorName;
        tmp.position = createdBrick.position;
        tmp.removed = false;
        spawnedBricks[i] = tmp;
    }

    public void GenerateRemovedBrick()
    {
      
        
        for (int i = 0; i < length; i++)
        {
            if (spawnedBricks[i].removed == true)
            {
                int temp = spawnedBricks[i].colorName;
                Transform createdBrick = Instantiate(brickPrefabs[temp], spawnedBricks[i].position, Quaternion.identity).transform;

                createdBrick.transform.SetParent(this.transform);
                spawnedBricks[i].removed = false;
               // return;
            }
        }
    }





}
