using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{

    public GameObject ball;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
            Debug.Log("collision has occured");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
