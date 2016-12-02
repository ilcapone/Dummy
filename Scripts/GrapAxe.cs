using UnityEngine;
using System.Collections;

public class GrapAxe : MonoBehaviour {

    GameObject Axe;
    GameObject Camera;
    bool grab = false;
    float d;

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

            Axe.transform.position = transform.position + forward.normalized*-0.1f;
            Axe.transform.position = new Vector3(Axe.transform.position.x+1.5f, Axe.transform.position.y, Axe.transform.position.z);
            Axe.transform.eulerAngles = new Vector3(Axe.transform.rotation.x, Axe.transform.rotation.y, 180);

            //drop object
            if (Input.GetKeyDown(KeyCode.R))
            {
                grab = false;
            }

            //atacar
            if (Input.GetMouseButtonDown(0))
            {

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

                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Axe"))
                    {
                        //coges la luna
                        Axe = GameObject.Find(hit.transform.gameObject.name);
                        Axe.transform.position = transform.position + forward.normalized;
                        //Axe.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                        grab = true;

                    }
                }
            }

        }

    }
}
