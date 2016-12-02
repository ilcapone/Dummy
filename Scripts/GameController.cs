using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    enum Nivel {
        cero,
        uno,
        dos,
        tres,
        cuatro
    }

    public GameObject[] Stars = new GameObject[4];
    public GameObject[] ghosts;
    GameObject FPS;


    bool level1inicialite = false;
    bool level2inicialite = false;
    bool level3inicialite = false;
    bool level4inicialite = false;


    //Stars Variables
    float x_star;
    float y_star;
    float z_star;
    Vector3 pos_star;
    int max_star = 3;

    //timers
    float time = 2;

    //variables fantasmas
    int maxGhsot = 30;
    int number_ghost = 0;
    int currentSpeed = 7;

    public int currentGhosts;

    //Ghost variables
    float x_ghost;
    float y_ghost;
    float z_ghost;
    Vector3 pos_ghost;

    //Box Variables
    public GameObject[] boxes;

    float x_Box;
    float y_Box;
    float z_Box;
    Vector3 pos_Box;

    int maxBox = 10;


    int currentStars = 0;
    int TotalPedestal = 0;
    string Level;

    //GUI

    float leng = 0;

    //3 y 6 NIVEES DE JUHABILIDAD

    // Use this for initialization
    void Start() {
        

        FPS =GameObject.Find("FPSController");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Level = "0";

        Stars[0].transform.position = new Vector3(323.58f, 52.9f, 239.51f);
        Stars[0].SetActive(true);
        Stars[1].SetActive(false);
        Stars[2].SetActive(false);
        Stars[3].SetActive(false);

        currentGhosts = maxGhsot;

        ghosts = new GameObject[maxGhsot];
        Ghost_InicialiteNewLevel();

        boxes = new GameObject[maxBox];
        Create_Boxes();


    }

    // Update is called once per frame
    void Update() {

       
       
        switch (Level)
        {
            case "0":
                {
                    controll_allGhostKill("1");

                    //GUI.Box(new Rect(45, 220, leng, 25), " G@@@@@s - Level 0");
                    break;
                }
            case "1":
                {
                    if (level1inicialite== false)
                    {
                        // Soltar la luna del player
                        //FPS.GetComponent<GrapMoon>().DropMoon();

                        Stars[0].SetActive(false);
                        Stars[1].SetActive(true);
                        Stars[2].SetActive(false);
                        Stars[3].SetActive(false);

                        maxGhsot = 50;
                        number_ghost = 0;
                        currentSpeed = 8;
                        currentGhosts = maxGhsot;
                        ghosts = new GameObject[maxGhsot];
                        Ghost_InicialiteNewLevel();
                        level1inicialite = true;

                        ///FPS.GetComponent<RandomPosition>().restarPosittionFPS(380.7f, 200f, 98.6f);
                        
                    }

                    controll_allGhostKill("2");

                    break;
                }
            case "2":

                if (level2inicialite == false)
                {
                    //FPS.GetComponent<GrapMoon>().DropMoon();

                    Stars[0].SetActive(false);
                    Stars[1].SetActive(false);
                    Stars[2].SetActive(true);
                    Stars[3].SetActive(false);

                    maxGhsot = 90;
                    number_ghost = 0;
                    currentSpeed = 10;
                    currentGhosts = maxGhsot;
                    ghosts = new GameObject[maxGhsot];
                    Ghost_InicialiteNewLevel();
                    level2inicialite = true;

                }

                controll_allGhostKill("3");
               
                break;
            case "3":

                if (level3inicialite == false)
                {
                    //FPS.GetComponent<GrapMoon>().DropMoon();

                    Stars[0].SetActive(false);
                    Stars[1].SetActive(false);
                    Stars[2].SetActive(false);
                    Stars[3].SetActive(true);

                    maxGhsot = 150;
                    number_ghost = 0;
                    currentSpeed = 15;
                    currentGhosts = maxGhsot;
                    ghosts = new GameObject[maxGhsot];
                    Ghost_InicialiteNewLevel();
                    level3inicialite = true;

                }

                controll_allGhostKill("4");
                
                break;
            case "4":

                SceneManager.LoadScene("Menu");
               // leng = Screen.width / 2;
               // GUI.Box(new Rect(45, 220, leng, 25), "Level 4");

                break;
        }

        /// si todos los fantasmas estan muertos, change level;
        //controll_allGhostKill();

    }
    public void Ghost_InicialiteNewLevel()
    {
        number_ghost = 0;
        while (number_ghost < maxGhsot)
        {

            GameObject ghost = Resources.Load("GhostShagowEnemi") as GameObject;
            ghosts[number_ghost] = Instantiate(ghost) as GameObject;
            x_ghost = Random.Range(223, 376);
            y_ghost = 80;
            z_ghost = Random.Range(68, 326);
            pos_ghost = new Vector3(x_ghost, y_ghost, z_ghost);
            ghosts[number_ghost].transform.position = pos_ghost;
            ghosts[number_ghost].GetComponent<EnemyMovement>().newSpeed(currentSpeed);
            number_ghost++;
        }
    }

    public void controll_allGhostKill(string nextLevel )
    {
        if (currentGhosts == 0)
        {
            Debug.Log("AllGhosts kkilled");
            time -= Time.deltaTime;
            if (time <= 0.0f)
            {
                Level = nextLevel;
                time = 2;

            }
        }

    }
    public void Create_Boxes()
    {
        int numBox = 0;
        while (numBox<maxBox)
        {
            GameObject box = Resources.Load("Box") as GameObject;
            boxes[numBox] = Instantiate(box) as GameObject;
            x_Box = Random.Range(223, 376);
            y_Box = 80;
            z_Box = Random.Range(68, 326);
            pos_Box = new Vector3(x_Box, y_Box, z_Box);
            boxes[numBox].transform.position = pos_Box;
            numBox++;
        }
    }

}
