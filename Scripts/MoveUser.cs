using UnityEngine;
using System.Collections;

public class MoveUser : MonoBehaviour {


    GameObject User;

    //Controladores HTC
    [SerializeField]
    GameObject thisController;
    int controllerIndex;

    [SerializeField]
    GameObject cube0;
    [SerializeField]
    GameObject cube1;
    [SerializeField]
    GameObject cube2;
    [SerializeField]
    GameObject cube3;
    [SerializeField]
    GameObject cube4;
    [SerializeField]
    GameObject cube5;
    [SerializeField]
    GameObject cube6;
    [SerializeField]
    GameObject cube7;
    [SerializeField]
    GameObject cube8;
    [SerializeField]
    GameObject cube9;


    string currentCubePosition;

    void Start()
    {
        
        User = GameObject.Find("[CameraRig]");

        //traked controller button to controller
        //trackedObj = GetComponent<SteamVR_TrackedObject>();

        controllerIndex = (int)thisController.GetComponent<SteamVR_TrackedObject>().GetDeviceIndex();
        currentCubePosition = "Cube";

    }

    void Update()
    {
        
        controllerIndex = (int)thisController.GetComponent<SteamVR_TrackedObject>().GetDeviceIndex();

        // Check for Trigger pull
        if (SteamVR_Controller.Input(controllerIndex).GetPressDown(SteamVR_Controller.ButtonMask.Axis1))
        {
            //RayCaster
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, forward, out hit, 1000f))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Position"))
                {
                    User.transform.position = new Vector3(hit.transform.position.x , hit.transform.position.y, hit.transform.position.z);
                    Deactivate_current_cubePosition(hit.transform.gameObject.name);

                    Activate_last_cubePosition(currentCubePosition);
                    currentCubePosition = hit.transform.gameObject.name;
                }

            }
        }

    }

    public void Deactivate_current_cubePosition(string newCubeposition)
    {
        
        switch (newCubeposition)
        {
            case "Cube":
                {
                    cube0.SetActive(false);
                    break;
                }
            case "Cube (1)":
                {
                    cube1.SetActive(false);
                    break;
                }
            case "Cube (2)":
                {
                    cube2.SetActive(false);
                    break;
                }
            case "Cube (3)":
                {
                    cube3.SetActive(false);
                    break;
                }
            case "Cube (4)":
                {
                    cube4.SetActive(false);
                    break;
                }
            case "Cube (5)":
                {
                    cube5.SetActive(false);
                    break;
                }
            case "Cube (6)":
                {
                    cube6.SetActive(false);
                    break;
                }
            case "Cube (7)":
                {
                    cube7.SetActive(false);
                    break;
                }
            case "Cube (8)":
                {
                    cube8.SetActive(false);
                    break;
                }
            case "Cube (9)":
                {
                    cube9.SetActive(false);
                    break;
                }
        }
        
    }

    public void Activate_last_cubePosition(string lastCubeposition)
    {

        switch (lastCubeposition)
        {
            case "Cube":
                {
                    cube0.SetActive(true);
                    break;
                }
            case "Cube (1)":
                {
                    cube1.SetActive(true);
                    break;
                }
            case "Cube (2)":
                {
                    cube2.SetActive(true);
                    break;
                }
            case "Cube (3)":
                {
                    cube3.SetActive(true);
                    break;
                }
            case "Cube (4)":
                {
                    cube4.SetActive(true);
                    break;
                }
            case "Cube (5)":
                {
                    cube5.SetActive(true);
                    break;
                }
            case "Cube (6)":
                {
                    cube6.SetActive(true);
                    break;
                }
            case "Cube (7)":
                {
                    cube7.SetActive(true);
                    break;
                }
            case "Cube (8)":
                {
                    cube8.SetActive(true);
                    break;
                }
            case "Cube (9)":
                {
                    cube9.SetActive(true);
                    break;
                }
        }

    }

}
