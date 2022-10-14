using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update



    Rigidbody rb;


    public Joystick joystick;

    public float speed;


    public Transform posAddBricks;


    public List<Transform> listBrickPlayer = new List<Transform>();

    public Transform playerRenderer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        print(QuantityBrick);
        JoystickMove();

    }

    Vector3 dir;
    void JoystickMove()
    {
        dir = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        rb.velocity = dir;

      //  transform.LookAt(dir);

    }

    // so luong gach
    int QuantityBrick = 0;


    void AddBrick(Collider collider)
    {
        QuantityBrick++;
        collider.transform.SetParent(posAddBricks.transform);
        listBrickPlayer.Add(collider.transform);
        collider.transform.localPosition = new Vector3(0, 0.25f * QuantityBrick, 0);

    }
   
    // add brick behind player


    //RaycastHit slopeHit;
    //float maxSlopeAngle;
    //private bool OnSlope()
    //{
    //    if(Physics.Raycast(transform.position,Vector3.down, out slopeHit))
    //    {
    //        float angle = Vector3.Angle(slopeHit.normal, Vector3.up);
    //        return angle < maxSlopeAngle && angle != 0;
    //    }
    //    return false;
    //}

    //Vector3 GetSlopeMoveDir()
    //{
    //    return Vector3.ProjectOnPlane(dir, slopeHit.normal).normalized;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            rb.useGravity = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            rb.useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // add brick
        if (other.gameObject.CompareTag("PlayerBrick"))
        {
            AddBrick(other);

        }

        if (other.gameObject.CompareTag("brick"))
        {
            other.GetComponent<MeshRenderer>().material = playerRenderer.GetComponent<MeshRenderer>().material;

            QuantityBrick--;
            if(QuantityBrick <=0)
            {
                QuantityBrick = 0;
            }

            if(posAddBricks.childCount>0)
               Destroy(posAddBricks.GetChild(posAddBricks.childCount-1).gameObject);

            if (QuantityBrick ==0 )
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
            }    

        }
    }







}
