using UnityEngine;
using System.Collections;
using System;
using System.Timers;
using UnityEngine.SceneManagement;

public class RayCaster_1_7 : MonoBehaviour
{
    bool iLookAtSomething = false;
    float timer = 1.5f; 
    //Definicion del plano uno y plano dos para su posterior manipulacion de tamaño cuand la camara los enfoque
    GameObject Camera;
    GameObject sphereshader;
    GameObject spherevideo1;
    GameObject spherevideo2;
    GameObject sphereshader2;
    //variables para gestionar el zoom progresivo de los planos
    float time1 = 1.3f;
    float x, y, z = 0;
    float xpos = 0;

    Double i2 = 0.5f;
    float time2 = 1f;
    //Variable para controlar si a comenzado el movimiento de la camara para crear la transicion de escenas 
    bool moving1 = false;
    bool moving2 = false;

    //Variables para saver que video se esta viendo
    bool video1 = false;
    bool video2 = false;


    void Start()
    {
        Camera = GameObject.Find("CardboardMain");
        sphereshader = GameObject.Find("SphereShader");
        spherevideo2 = GameObject.Find("Sphere2");
        spherevideo1 = GameObject.Find("Sphere1");
        video1 = true;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, -1))
        {
            // planouno.transform.localScale = new Vector3(0.2f, 0.2f, 0.1f); //transformacion del plano, en este caso se hace mas grande cuand es observado
            if (video1 == true)
            {
                sphereshader.transform.localScale = new Vector3(3.8f, 3.8f, 3.8f);
                Debug.Log("Esfera uno observada");
            }
            if (video2 == true)
            {
                sphereshader.transform.localScale = new Vector3(3.8f, 3.8f, 3.8f);
                Debug.Log("Esfera dos observada1");
            }
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                iLookAtSomething = true;
                // ************* CODIGO PARA LA DE DECCION DE LOS PLANOS ***************
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Esfera1"))
                {
                    moving1 = true;
                }
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Esfera2"))
                {
                    moving2 = true;
                    Debug.Log("Esfera dos observada2");
                }
            }
        }
        else
        {
            timer = 1.5f;
            // planouno.transform.localScale = new Vector3(0.1476738f, 0.1476738f, 0.07383692f);
            if (video1 == true)
            {
                sphereshader.transform.localScale = new Vector3(2.8f, 2.8f, 2.8f);
            }
            if (video2 == true)
            {
                sphereshader.transform.localScale = new Vector3(2.8f, 2.8f, 2.8f);
            }
            iLookAtSomething = false;
        }

        //Gestion del movimiento respecto al tiempo, solo se activa cuand miras el plano mas de 3 segundos
        if (moving1 == true)
        {
                time1 -= Time.deltaTime;
                if (time1 > 0)
                { 
                    transition();
                }
                else
                {
                //gestion de las nuevas posiciones y propiedades tanto de las esferas que contienen los videos como de del shader que interactua con ellas
                sphereshader.transform.position = new Vector3(0, 0, 0);
                moving1 = false;
                time1 = 2f;
                video1 = false;
                video2 = true;

                // la esfera dos pasa a estar por fuera
                spherevideo2.transform.localScale = new Vector3(15, 15, 15);
                spherevideo1.transform.localScale = new Vector3(10, 10, 10);

                //se desactiva el shader para que no interfiera en la transicion
                sphereshader.SetActive(false);
                // se mueve el shader para crear el nuevo portal
                sphereshader.transform.position = new Vector3(5.31f, 0, 0);

                //se desactiva el video uno para q n interfiera en la transicion
                spherevideo1.SetActive(false);
                //se elimina el componente, para que deje de interactuar con el Shader
                //Destroy(spherevideo1.GetComponent<SetRenderQueue>());
                //spherevideo1.GetComponent<SetRenderQueue>().activado = false;
                //spherevideo1.SetActive(true);

                //añadimos el componente que interactua con el shader a la esfera dos
                //spherevideo2.AddComponent<SetRenderQueue>();
                //reactivamos el shader
                sphereshader.SetActive(true);

                //cambiamos el layer del shader para q pueda iniciar el movimiento de transicion 2 (moving2)
                sphereshader.layer = LayerMask.NameToLayer("Esfera2");

            }
        }
        if (moving2 == true)
        {
            //controlar la segunda transicion entre escenas
                time2 -= Time.deltaTime;
                if (time2 > 0)
                {
                    transition2();
                }
                else
                {
                //gestion de las nuevas posiciones y propiedades tanto de las esferas que contienen los videos como de del shader que interactua con ellas
                sphereshader.transform.position = new Vector3(0, 0, 0);
                moving2 = false;
                time2 = 2f;
                video1 = true;
                video2 = false;

                // la esfera uno pasa a estar por fuera
                spherevideo1.transform.localScale = new Vector3(15, 15, 15);
                spherevideo2.transform.localScale = new Vector3(10, 10, 10);

                //se desactiva el shader para que no interfiera en la transicion
                sphereshader.SetActive(false);
                // se mueve el shader para crear el nuevo portal
                sphereshader.transform.position = new Vector3(-5.61f, 0, 0);

                //se desactiva el video dos para q n interfiera en la transicion
                spherevideo2.SetActive(false);
                //se elimina el componente, para que deje de interactuar con el Shader
                //Destroy(spherevideo1.GetComponent<SetRenderQueue>());
                //spherevideo2.GetComponent<SetRenderQueue>().activado = false;
                spherevideo2.SetActive(true);

                //añadimos el componente que interactua con el shader a la esfera uno
               // spherevideo1.AddComponent<SetRenderQueue>();
                //reactivamos el shader
                sphereshader.SetActive(true);

                //cambiamos el layer del shader para q pueda iniciar el movimiento de transicion 2 (moving2)
                sphereshader.layer = LayerMask.NameToLayer("Esfera1");
            }
        }
    }

    public void transition()
    {
        sphereshader.transform.position = new Vector3(sphereshader.transform.position.x + 0.17f, 0, 0);
    }
    public void transition2()
    {
        sphereshader.transform.position = new Vector3(sphereshader.transform.position.x - 0.17f, 0, 0);
    }
}