using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor 
{
    Red,Green,Blue,
}

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;


    public DynamicJoystick dynamicJoystick;


    public float speed;
    public Transform posAddBricks;

    public List<Transform> listBrickPlayer = new List<Transform>();

    public Transform playerRenderer;

    public Material[] playerMaterials;

    public PlayerColor playerColor;

    public BrickGenerator brickGenerator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Start()
    {
        RandomPlayerColor();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      
        JoystickMove();

        print(QuantityBrick);
  

    }

    public void RandomPlayerColor()
    {
        int ran = Random.Range(0, playerMaterials.Length);

        switch (ran)
        {
            case 0:
                playerColor = PlayerColor.Red;
                    break;
            case 1:
                playerColor = PlayerColor.Green;
                break;
            case 2:
                playerColor = PlayerColor.Blue;
                break;       
          
        }

        playerRenderer.GetComponent<MeshRenderer>().material = playerMaterials[ran];


    }
  
    void JoystickMove()
    {

         rb.velocity = new Vector3(dynamicJoystick.Horizontal * speed, rb.velocity.y, dynamicJoystick.Vertical * speed);
        
        float angleA = Mathf.Atan2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical) * Mathf.Rad2Deg;

        if(angleA != 0)
        transform.rotation = Quaternion.Euler(0f, angleA, 0f);

    }

   

    // so luong gach
    int QuantityBrick = 0;


    void AddBrick(Collider collider)
    {
        QuantityBrick++;

        collider.transform.SetParent(posAddBricks.transform);
               
        listBrickPlayer.Add(collider.transform);

        collider.transform.localPosition = new Vector3(0, 0.25f * QuantityBrick, 0);
        collider.transform.localRotation = Quaternion.identity;
      
    }

 

    private void OnTriggerEnter(Collider other)
    {

        if( other.gameObject.CompareTag("brick") && (int)playerColor == (int)other.GetComponent<Brick>().brickColor)
        {
              brickGenerator.MakeRemoved(other.GetComponent<Brick>().numberBrick);
              AddBrick(other);
        }


        if ( other.gameObject.CompareTag("slope"))
        {
            other.GetComponent<MeshRenderer>().material = playerRenderer.GetComponent<MeshRenderer>().material;
           

            if (posAddBricks.childCount > 0  && QuantityBrick > 0)
            {
                
                GameObject lastChild = posAddBricks.GetChild(posAddBricks.childCount - 1).gameObject;
                Destroy(lastChild);
                 QuantityBrick--;
               
            }         


            if (QuantityBrick == 0)
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
            }

        }
    }

   
    private void OnSlope()
    {
      
    }



}
