using UnityEngine;
using System.Collections;

public class DiaNoche : MonoBehaviour {

    GameObject sun;

    void Start()
    {
        sun = GameObject.Find("DirectionalLight");
       
    }

    // Update is called once per frame
    void Update () {
        sun.transform.Rotate(Vector3.right * Time.deltaTime);
    }
}
