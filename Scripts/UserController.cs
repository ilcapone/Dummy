using UnityEngine;
using System.Collections;

public class UserController : MonoBehaviour {

    GameObject Menu;
    GameObject grabbedObject;
    float grabbedObjectSize;
    GameObject FPS;
    float d;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    // Use this for initialization
    void Start () {

        Menu = GameObject.Find("CardboardMain");
        FPS = GameObject.Find("FPSController");

    }

    // Update is called once per frame
    void Update () {

        Vector3 forward = transform.TransformDirection(Vector3.up);
        Debug.DrawRay(transform.position, forward, Color.red);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
                if (grabbedObject == null)
                    TryGrabObject(GetMouseHoverObject(5));
                else
                    DropObject();
            else
                DropObject();
        }

        if (grabbedObject != null)
        {

            grabbedObject.transform.position = transform.position + forward.normalized * d;
        }

        
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("space key was pressed");


        }
    }
    void TryGrabObject(GameObject grabObject)
    {
        //if (grabObject == null || CanGrab(grabbedObject))
        if (grabObject == null)
            return;
        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    void DropObject()
    {
        if (grabbedObject == null)
            return;

        /* if (grabbedObject.GetComponent<Rigidbody>() != null)
             grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;*/
        grabbedObject = null;
    }
}
