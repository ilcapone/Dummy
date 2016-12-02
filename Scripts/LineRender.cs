using UnityEngine;
using System.Collections;

public class LineRender : MonoBehaviour {

    

    LineRenderer mGun;
    float mGunCountDown = 0.125f;
    float mCurrentCountDown = 0.0f;
    float d;

    void Start()
    {
        mGun = GetComponent<LineRenderer>();
        mGun.enabled = false;
        mGun.SetVertexCount(2);
        mGun.SetWidth(0.01f, 0.01f);
        mGun.SetColors(Color.yellow, Color.yellow);
    }

    void Update()
    {
        
            mGun.enabled = true;
            mGun.SetPosition(0, transform.position);
            mGun.SetPosition(1, transform.TransformDirection(Vector3.forward) * 1000);
       
    }
}
