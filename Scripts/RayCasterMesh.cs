using UnityEngine;
using System.Collections;
using System;
using System.Timers;
using UnityEngine.SceneManagement;

public class RayCasterMesh : MonoBehaviour
{
    bool iLookAtSomething = false;
    //Definicion del plano uno y plano dos para su posterior manipulacion de tamaño cuand la camara los enfoque
   
    GameObject FPS;
    GameObject ObjectStar;
    GameObject grabbedObject;
    float grabbedObjectSize;
    float time1 = 2f;
    bool grabStar = false;
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


    void Start()
    {
        
        FPS = GameObject.Find("FPSController");
    }

    void Update()
    {
        //click derecho del raton
        if (Input.GetMouseButtonDown(1))
        {
            //direccion del raycaster
            Vector3 up = FPS.transform.TransformDirection(Vector3.up);
            Debug.DrawRay(transform.position, up, Color.red);
            RaycastHit hit;
            if (grabStar == true)
            {
                //ya esta agarrada la esfera por lo qe se referesca su posicion para q te siga
                ObjectStar.transform.position = transform.position + up.normalized * d;
            }
            else
            {

                if (Physics.Raycast(transform.position, up, out hit, 100f))
                {
                    d = hit.distance;
                    iLookAtSomething = true;
                    Debug.Log("Pressed middle click.");
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Star"))
                    {
                        
                        ObjectStar = GameObject.Find(hit.collider.gameObject.name);
                        ObjectStar.transform.position = transform.position + up.normalized * d;
                        grabStar = true;
                    }
                }
                else
                {
                    iLookAtSomething = false;
                }
            }
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