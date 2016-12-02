using UnityEngine;
using System.Collections;

public class GrapBasicObject : MonoBehaviour
{

    GameObject basicObject;
    bool grab = false;
    float d;

    GameObject ghostinTrap;
    bool grabghost = false;

    bool puttrap = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        //primero comprovamos si tiene una objeto
        if (grab == true)
        {

            basicObject.transform.position = transform.position + forward.normalized * d;

            if (grabghost == true)
            {
                //colocamos la trampa
                if (Input.GetMouseButtonDown(1))
                {
                    grab = false;
                    basicObject.transform.localScale = new Vector3(36.25414f, 34.98035f, 42.10256f);
                    basicObject.transform.position = new Vector3(basicObject.transform.position.x, transform.position.y, basicObject.transform.position.z);
                    //ghostinTrap.transform.position = new Vector3(basicObject.transform.position.x, transform.position.y, basicObject.transform.position.z);
                    //ghostinTrap.SetActive(true);
                    basicObject = null;
                    ghostinTrap = null;
                    grabghost = false;
                }
            }
            else
            {
                //ig be a ghost tram tem , else drop de basic object
                if (Input.GetMouseButtonDown(1))
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, forward, out hit, 100f))
                    {
                        d = hit.distance;

                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ghost"))
                        {
                            //capturas un fantasma
                            ghostinTrap = GameObject.Find(hit.transform.gameObject.name);
                            //ghostinTrap.transform.position = transform.position + forward.normalized * d;

                            ghostinTrap.SetActive(false);

                            //disminulle la caja
                            basicObject.transform.localScale = new Vector3(10f, 10f, 10f);
                            //ghostinTrap.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

                            grab = true;
                            grabghost = true;

                        }
                        else
                        {
                            //drop object
                            grab = false;
                            basicObject.transform.position = new Vector3(basicObject.transform.position.x, transform.position.y, basicObject.transform.position.z);
                            basicObject = null;
                            ghostinTrap = null;

                        }
                    }
                }
            }

         }
        else
        {
            //si no tiene objeto gestionamos el evento para coger un objeto
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, forward, out hit, 100f))
                {
                    d = hit.distance;

                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("BasicObject"))
                    {
                        //coges la luna
                        basicObject = GameObject.Find(hit.transform.gameObject.name);
                        basicObject.transform.position = transform.position + forward.normalized * d;
                        grab = true;

                    }
                }
            }

        }

    }
  }

