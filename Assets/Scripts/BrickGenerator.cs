using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickGenerator : MonoBehaviour
{

    [System.Serializable]
    public class SpawnedBricks
    {
        public ColorType brickColorName;
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
  

     
    public void Start()
    {
        
        OnInit();

        InvokeRepeating(nameof(GenerateRemovedBrick), 1f, 1f);
    }

    void OnInit()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;

        spawnedBricks = new SpawnedBricks[length];

        CreateBricks();

       
    }


    public void CreateBricks()
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


            InsertIntoArray(createdBrick, createdBrick.GetComponent<Brick>().brickColor,i);

        }
    }

    public void MakeRemoved(int brickNumber)
    {
       
        spawnedBricks[brickNumber].removed = true;
    }
    private void InsertIntoArray(Transform createdBrick, ColorType colorName, int i)
    {
        var tmp = new SpawnedBricks();
        tmp.brickColorName  = colorName;
        tmp.position = createdBrick.position;
        tmp.removed = false;
        spawnedBricks[i] = tmp;
    }
 
    public void GenerateRemovedBrick()
    {
     
        for (int i = 0; i < spawnedBricks.Length; i++)
        {
            if (spawnedBricks[i].removed == true)
            {
                int temp = (int)spawnedBricks[i].brickColorName;
                Transform createdBrick = Instantiate(brickPrefabs[temp], spawnedBricks[i].position, Quaternion.identity).transform;

                // add lai brick vao day
              //  InsertIntoList(createdBrick, createdBrick.GetComponent<Brick>().brickColor);

                //   spawnedBricks[i] = createdBrick;
                spawnedBricks[i].removed = false;
                
                createdBrick.transform.SetParent(this.transform);
             
            }
        }
    }


    public void ShuffleBrick()
    {
        for (int t = 0; t < spawnedBricks.Length; t++)
        {
            int r = Random.Range(t, spawnedBricks.Length);
            spawnedBricks[t] = spawnedBricks[r];
   
        }
    }






}
