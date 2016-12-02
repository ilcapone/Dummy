using UnityEngine;
using System.Collections;

public class InmersiveController : MonoBehaviour {

    public GameObject[] Stars = new GameObject[4];
    public GameObject[] ghosts;
    GameObject USer;

    //Stars Variables
    float x_star;
    float y_star;
    float z_star;
    Vector3 pos_star;
    int max_star = 3;

    //variables fantasmas
    int maxGhsot = 50;
    int number_ghost = 0;
    int currentSpeed = 1;

    //Ghost variables
    float x_ghost;
    float y_ghost;
    float z_ghost;
    Vector3 pos_ghost;

    // Use this for initialization
    void Start () {

        //control USer
        USer = GameObject.Find("[CameraRig]");


        //cintrol spheras
        /*Stars[0].transform.position = new Vector3(323.58f, 52.9f, 239.51f);
        Stars[0].SetActive(true);
        Stars[1].SetActive(true);
        Stars[2].SetActive(true);
        Stars[3].SetActive(true);*/

        ghosts = new GameObject[maxGhsot];
        Ghost_InicialiteNewLevel();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Ghost_InicialiteNewLevel()
    {
        number_ghost = 0;
        while (number_ghost < maxGhsot)
        {

            GameObject ghost = Resources.Load("GhostShagowEnemiInmersive") as GameObject;
            ghosts[number_ghost] = Instantiate(ghost) as GameObject;
            x_ghost = Random.Range(-100, 100);
            y_ghost = 10;
            z_ghost = Random.Range(-100, 100);
            pos_ghost = new Vector3(x_ghost, y_ghost, z_ghost);
            ghosts[number_ghost].transform.position = pos_ghost;
            ghosts[number_ghost].GetComponent<EnemyMovementInmersive>().newSpeed(currentSpeed);
            number_ghost++;
        }
    }
}
