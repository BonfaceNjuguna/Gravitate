using UnityEngine;

public class Disc : MonoBehaviour
{
    public GameObject checker;
    public Camera aimCamera;

    private GameObject checkObj;


    public static event System.Action<Vector3> onGravityChange;

    public float gravityScale = 9.81f;

    public void Start()
    {
        checkObj = GameObject.Instantiate(checker);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(aimCamera.transform.position, aimCamera.transform.forward, out hit))
        {;
            if (hit.transform.tag == "GravitySwap")
            {
                // hit.transform.gameObject.GetComponent<RotateGrav>().RotateGravity();
                checkObj.transform.position = hit.point;
                checkObj.transform.up = hit.normal;
                ChangeGravity(checkObj.transform.rotation.eulerAngles);
            } else if (hit.transform.tag == "StopGravity") {
                Rigidbody hitRB = hit.rigidbody;

                Debug.Log(hitRB.constraints);
                if (hitRB.constraints == RigidbodyConstraints.FreezeRotation)
                {
                    hitRB.constraints = RigidbodyConstraints.FreezeAll;
                }
                else {
                    hitRB.constraints = RigidbodyConstraints.FreezeRotation;
                }
            }
        }

    }



    public void  ChangeGravity(Vector3 rotation)
    {
        Debug.Log(rotation);
        Debug.Log((int)rotation.z);
        if (rotation.x==0 && rotation.y==0 && rotation.z==0)
        {
            Physics.gravity = new Vector3(0.0f, -gravityScale, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Vector3.zero);
        }
        else if (rotation.z == 180f)
        {
            Physics.gravity = new Vector3(0.0f, gravityScale, 0);
            Debug.Log(Physics.gravity);
            onGravityChange?.Invoke(rotation);
        }
        else if (rotation.z >89 && rotation.z < 91)
        {
            Debug.Log(rotation.z);
            Physics.gravity = new Vector3(gravityScale, 0.0f, 0);
            Debug.Log(Physics.gravity);
            onGravityChange?.Invoke(rotation);
        }
        else if (rotation.z == 270f)
        {
            Physics.gravity = new Vector3(-gravityScale, 0.0f, 0);
            Debug.Log(Physics.gravity);
            onGravityChange?.Invoke(rotation);
        }
        else if (rotation.x > 89 && rotation.x < 91)
        {
            Debug.Log(rotation.z);
            Physics.gravity = new Vector3(0.0f, 0,-gravityScale);
            Debug.Log(Physics.gravity);
            onGravityChange?.Invoke(rotation);
        }
        else if (rotation.x == 270f)
        {
            Physics.gravity = new Vector3( 0.0f, 0, gravityScale);
            Debug.Log(Physics.gravity);
            onGravityChange?.Invoke(rotation);
        }
        //if (gravity.y ==1 )
        //{
        //    Physics.gravity = new Vector3(0.0f, gravityScale,  0);
        //    Debug.Log(Physics.gravity);
        //    onGravityChange?.Invoke(gravity);
        //} else if(gravity.y==-1){
        //    Physics.gravity = new Vector3( 0, -gravityScale, 0);
        //    Debug.Log(Physics.gravity);
        //    onGravityChange?.Invoke(gravity);
        //}
        /*
        switch (gravityDirection)
        {
            case Gravity.POSITIVEX:
               ;
                break;
            case Gravity.NEGATIVEX:
                
                break;
            case Gravity.POSITIVEY:
                Physics.gravity = new Vector3(0.0F, gravityScale, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.NEGATIVEY:
                Physics.gravity = new Vector3(0.0F, -gravityScale, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.POSITIVEZ:
                Physics.gravity = new Vector3(0.0F, 0, gravityScale);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            case Gravity.NEGATIVEZ:
                Physics.gravity = new Vector3(0.0F, 0, -gravityScale);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
            default:
                Physics.gravity = new Vector3(0.0F, -gravity, 0);
                Debug.Log(Physics.gravity);
                onGravityChange?.Invoke(Physics.gravity);
                break;
        }*/
    }
    }
