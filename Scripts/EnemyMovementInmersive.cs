using UnityEngine;
using System.Collections;

public class EnemyMovementInmersive : MonoBehaviour {

    public int rotateSpeed = 10;
    public int movementSpeed;

    public float maxDistance = 0.02f;

    private Transform myTransform;
    public Transform target;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("[CameraRig]/Camera (head)/Camera (eye)");
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
