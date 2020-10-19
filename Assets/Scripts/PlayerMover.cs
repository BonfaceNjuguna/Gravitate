using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public Transform roofCheck;
    public float groundDistance = 0.4f;
    public float roofDistance = 1.0f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    [SerializeField]
    protected bool isGrounded;
    [SerializeField]
    protected bool canJump;
    [SerializeField]
    protected bool isGravitychanging;

    Vector3 movement;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Disc.onGravityChange += Rotate;
        Debug.Log(Physics.gravity);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded )
        {
            isGravitychanging = false;
            canJump = false;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        //rb.MovePosition(transform.position + movement);
        //Vector3 forwardMove = transform.forward + movement;
        //rb.MovePosition(forwardMove);
        if (v != 0)
        {
            //Debug.Log(v);
            rb.MovePosition(transform.position + transform.forward * (v*speed) * Time.deltaTime);
            //rb.AddForce(transform.forward *v*speed*Time.deltaTime*150, ForceMode.Impulse);
        }
        if (h != 0)
        {
            rb.MovePosition(transform.position + transform.right * (h * speed) * Time.deltaTime);
        }
        //rb.MovePosition(transform.position+transform.forward*speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Rotate(Vector3 direction)
    {
        Debug.Log(direction);
        transform.eulerAngles = direction;
    }
    //public void Rotate(Vector3 gravitydirection)
    //{
    //    if (gravitydirection.y > 0)
    //    {
    //        transform.eulerAngles = new Vector3(0, 0, 180f);
    //    }
    //    else if (gravitydirection.y < 0)
    //    {
    //        transform.eulerAngles = new Vector3(0, 0, 0);
    //    }
    //    else if (gravitydirection.x > 0)
    //    {
    //        transform.eulerAngles = new Vector3(0, 0, 90);
    //    }
    //    else if (gravitydirection.x < 0)
    //    {
    //        transform.eulerAngles = new Vector3(0, 0, -90);
    //    }
    //    else if (gravitydirection.z > 0)
    //    {
    //        transform.eulerAngles = new Vector3(-90, 0, 0);
    //    }
    //    else if (gravitydirection.z < 0)
    //    {
    //        transform.eulerAngles = new Vector3(90, 0, 0);
    //    }
    //}
}
