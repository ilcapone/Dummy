using UnityEngine;
using System.Collections;
using System;
using System.Timers;
using UnityEngine.SceneManagement;

public class RayCaster : MonoBehaviour
{
    bool iLookAtSomething = false;
    float timer = 3.0f;
    public GameObject DirectionalLoght;
    public GameObject Murdag;
    int layer;
    bool moving = false;
    float time = 15f;
    float timeLeft = 2f;
    Vector3 v0;
    Vector3 v1;
    Vector3 v2;
    bool t1 = false;
    bool t2 = false;
    Double i = 2f;

    float y;


    void Start()
    {

        //plane.SetActive(false);

        // v0 = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z); //recoge la posicion de la camara y se guarfa en el vector v0
        //DirectionalLoght.GetComponent < "DirectionalLight" > ();
    }

    void OnGUI()
    {
        if (iLookAtSomething) {
           
            timer = 3.0f;
            if (layer == 1)
            {
                moving = true;
                //Camera.transform.rotation = Quaternion.Euler(0, 0, 0);            //Para transformar el angulo de la camara(Para el CardBoard se modifican los parametros del Head)
            }
            layer = 0;
            iLookAtSomething = false;

        }
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, -1))
        {
            //plane.SetActive(true);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                iLookAtSomething = true;
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MurdagLayer"))
                {
                    layer = 1;
                    Debug.Log("Murdag activado");

                }
            }
            
        }
        else
        {
            //plane.SetActive(false);
            iLookAtSomething = false;
        }

        //Gestion del movimiento respecto al tiempo, solo se activa cuand miras el plano mas de 3 segundos
        if (moving == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > 0)
            {
                i = i - 0.1;
                if (timeLeft < i)
                {
                   // Camera.transform.position = new Vector3(Camera.transform.position.x - 7, Camera.transform.position.y, Camera.transform.position.z);
                }
                else
                {
                    i = i + 0.1;
                }
            }
            else
            {
               // Camera.transform.position = new Vector3(27.1674f, -317, 18.77461f);
            }


        }


    }

}
