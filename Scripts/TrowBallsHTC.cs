using UnityEngine;
using System.Collections;

public class TrowBallsHTC : MonoBehaviour {


    //Controladores HTC
    [SerializeField]
    GameObject thisController;
    int controllerIndex;

    GameObject prefab;
    GameObject prefab1;
    // Use this for initialization
    void Start () {
        prefab = Resources.Load("Shurikenhtc") as GameObject;
        //prefab1 = Resources.Load("kunai") as GameObject;

        controllerIndex = (int)thisController.GetComponent<SteamVR_TrackedObject>().GetDeviceIndex();

    }
	
	// Update is called once per frame
	void Update () {



        controllerIndex = (int)thisController.GetComponent<SteamVR_TrackedObject>().GetDeviceIndex();

        // Check for Trigger pull
        if (SteamVR_Controller.Input(controllerIndex).GetPressDown(SteamVR_Controller.ButtonMask.Axis1))
        {
            GameObject proyectil = Instantiate(prefab) as GameObject;
            proyectil.transform.position = transform.position + thisController.transform.forward * 2;
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            rb.velocity = thisController.transform.forward * 60;
        }

    }
}
