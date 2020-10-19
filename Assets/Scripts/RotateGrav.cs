using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrav : MonoBehaviour
{
    // Start is called before the first frame update
    // add event  in player mover add  method
    public Gravity gravityDirection;
    public enum Gravity { 
        POSITIVEX,
        NEGATIVEX,
        POSITIVEY,
        NEGATIVEY,
        POSITIVEZ,
        NEGATIVEZ
    }

    public static event Action<Vector3> onGravityChange;

    public float gravity = 9.81f;

    public void RotateGravity() {
        Debug.Log("RotateGravity() " + gravityDirection);
        switch (gravityDirection)
        {
            case Gravity.POSITIVEX:
                Physics.gravity = new Vector3(gravity, 0.0f, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.NEGATIVEX:
                Physics.gravity = new Vector3( -gravity, 0, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.POSITIVEY:
                Physics.gravity = new Vector3(0.0F, gravity, 0);
                Debug.Log(Physics.gravity);
                 onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.NEGATIVEY:
                Physics.gravity = new Vector3(0.0F, -gravity, 0 );
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.POSITIVEZ:
                Physics.gravity = new Vector3(0.0F, 0, gravity);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.NEGATIVEZ:
                Physics.gravity = new Vector3(0.0F, 0, -gravity);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            default:
                Physics.gravity = new Vector3(0.0F, -gravity, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
        }
    }
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (Physics.gravity.x == gravity)
    //        {
    //            Physics.gravity = new Vector3(-gravity, 0.0F, 0);
    //            onGravityChange?.Invoke(Physics.gravity);

    //        }
    //        else
    //        if (Physics.gravity.x == -gravity)
    //        {
    //            Physics.gravity = new Vector3(0, gravity, 0);
    //            onGravityChange?.Invoke(Physics.gravity);

    //        }
    //        else
    //        if (Physics.gravity.y == gravity)
    //        {
    //            Physics.gravity = new Vector3(0, -gravity, 0);
    //            onGravityChange?.Invoke(Physics.gravity);

    //        }
    //        else
    //        {
    //            Physics.gravity = new Vector3(gravity, 0, 0);
    //            onGravityChange?.Invoke(Physics.gravity);

    //        }
    //    }
    //}
}
