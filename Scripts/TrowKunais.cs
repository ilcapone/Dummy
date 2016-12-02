using UnityEngine;
using System.Collections;

public class TrowKunais : MonoBehaviour {

    GameObject prefab;
    // Use this for initialization
    void Start()
    {
        prefab = Resources.Load("kunai") as GameObject;
        //prefab1 = Resources.Load("kunai") as GameObject;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject proyectil = Instantiate(prefab) as GameObject;
            proyectil.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;

        }

        /*if (Input.GetMouseButtonDown(1))
        {
            GameObject proyectil = Instantiate(prefab1) as GameObject;
            proyectil.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;

        }*/

    }
}
