using UnityEngine;
using System.Collections;

public class FreeWorldController : MonoBehaviour {

    public GameObject[] Stars = new GameObject[4];
    public GameObject[] ghosts;
    GameObject FPS;
    GameObject GhostTrap;

    //Stars Variables
    float x_star;
    float y_star;
    float z_star;
    Vector3 pos_star;
    int max_star = 3;

    //variables fantasmas
    int maxGhsot = 6;
    int number_ghost = 0;
    int currentSpeed = 7;

    //Ghost variables
    float x_ghost;
    float y_ghost;
    float z_ghost;
    Vector3 pos_ghost;

    // Ghost position zones
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;
    public Vector3 position4;

    //Box Variables
    public GameObject[] boxes;

    float x_Box;
    float y_Box;
    float z_Box;
    Vector3 pos_Box;

    int maxBox = 20;


    int currentStars = 0;
    int TotalPedestal = 0;

    // Use this for initialization
    void Start () {
        
        //control USer
        FPS = GameObject.Find("FPSController");
        GhostTrap = GameObject.Find("GhostTrap");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        //cintrol spheras
        Stars[0].transform.position = new Vector3(323.58f, 52.9f, 239.51f);
        Stars[0].SetActive(true);
        Stars[1].SetActive(true);
        Stars[2].SetActive(true);
        Stars[3].SetActive(true);

        //control ghost
        ghosts = new GameObject[maxGhsot];

        //control zone ghost position
        int i = 0;
        while (i < 4)
        {
           
            Create_Ghost_Position(i);
            i++;
        }

        
       

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Create_Ghost_Position(int position)
    {
        number_ghost = 0;
        while (number_ghost < maxGhsot)
        {


            GameObject ghost = Resources.Load("GhostShagowEnemiFree-Carruaje") as GameObject;
            ghosts[number_ghost] = Instantiate(ghost) as GameObject;

            pos_ghost = Get_RandomPosition_zone(position);
           

            //TrapGhost
           // pos_ghost = new Vector3(GhostTrap.transform.position.x, GhostTrap.transform.position.y, GhostTrap.transform.position.z);
            

            ghosts[number_ghost].transform.position = pos_ghost;
            ghosts[number_ghost].GetComponent<EnemiDetectPlayer>().newSpeed(currentSpeed);
            number_ghost++;
        }
    }

    public Vector3 Get_RandomPosition_zone(int zone)
    {
        Vector3 Position_zone = new Vector3();
        switch (zone)
        {
            case 0:
                {
                    Debug.Log("Case 0");
                    x_ghost = Random.Range(-158.3043f, -168.2543f);
                    y_ghost = -54.14861f;
                    z_ghost = Random.Range(71.4485f, 71.4485f);
                    Position_zone = new Vector3(x_ghost, y_ghost, z_ghost);
                    break;
                }
            case 1:
                {
                    Debug.Log("Case 1");
                    break;
                }
            case 2:
                {
                    Debug.Log("Case 2");
                    break;
                }
            case 3:
                {
                    Debug.Log("Case 3");
                    break;
                }

        }

        return Position_zone;
    }
   
}
