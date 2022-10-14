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

        JoystickMove();

    }

    void JoystickMove()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

    }

    float t = 0;
  
   // add brick behind player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBrick"))
        {
            t++;
            other.transform.SetParent(posAddBricks.transform);
            listBrickPlayer.Add(other.transform);
            other.transform.localPosition = new Vector3(0, 0.25f * t, 0);

        }
    }





}
