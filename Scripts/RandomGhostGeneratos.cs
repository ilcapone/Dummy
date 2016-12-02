using UnityEngine;
using System.Collections;

public class RandomGhostGeneratos : MonoBehaviour {


    public GameObject[] ghosts;

    float x;
    float y;
    float z;
    Vector3 pos;

    public int maxGhsot;
    int number_ghost = 0;

    void Start()
    {
        
        ghosts= new GameObject[maxGhsot];

    }

    // Update is called once per frame
    void Update () {

        if (number_ghost < maxGhsot)
        {

            GameObject ghost = Resources.Load("GhostShagowEnemi") as GameObject;
            ghosts[number_ghost] = Instantiate(ghost) as GameObject;
            x = Random.Range(223, 376);
            y = 80;
            z = Random.Range(68, 326);
            pos = new Vector3(x, y, z);
            ghosts[number_ghost].transform.position = pos;
            number_ghost++;
        }

	
	}
}
