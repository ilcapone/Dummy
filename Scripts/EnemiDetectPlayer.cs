using UnityEngine;
using System.Collections;

public class EnemiDetectPlayer : MonoBehaviour {

    public int rotateSpeed = 10;
    public int movementSpeed;

    public int maxDistance = 2;

    private Transform myTransform;
    public Transform target;

    bool iLookAtPlayer = false;

    

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.Find("FPSController");
        target = go.transform;

        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {


        if (iLookAtPlayer == false)
        {
            //rota respecto a y para buscarlo
            myTransform.transform.Rotate(Vector3.right * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, -1))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MurdagLayer"))
                {
                    iLookAtPlayer = true;
                }

            }
        }
        else {
            //Atacamos al enemigo
            moveTowardEnemy();
        }

    }

    void moveTowardEnemy()
    {
        Debug.DrawLine(myTransform.position, target.position, Color.red);
        //rotate enemy
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotateSpeed * Time.deltaTime);
        if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
        {
            //move
            myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime;
        }
    }

    public void newSpeed(int newspeed)
    {
        movementSpeed = newspeed;
    }
    
}
