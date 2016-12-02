using UnityEngine;
using System.Collections;

public class LookkAt : MonoBehaviour {

   
    GameObject FPS;

    void Start()
    {
        FPS = GameObject.Find("FPSController");
    }

    void Update()
    {
        transform.LookAt(new Vector3(FPS.transform.position.x, transform.position.y, FPS.transform.position.z));
    }
}
