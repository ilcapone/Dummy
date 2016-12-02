using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public int rotateSpeed = 10;
    public int movementSpeed;

    public int maxDistance = 2;

    private Transform myTransform;
    public Transform target;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("FPSController/FirstPersonCharacter");
        target = go.transform;

        myTransform = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        moveTowardEnemy();


    }

    void moveTowardEnemy()
    {
        Debug.DrawLine(myTransform.position,target.position, Color.red);
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
