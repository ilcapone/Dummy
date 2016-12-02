using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour
{

    float x;
    float y= 200;
    float z;
    Vector3 pos;
    void Start()
    {
        x = Random.Range(223, 376);
        z = Random.Range(68, 326);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    public void restarPosittionFPS(float x, float y, float z) {
        
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }
}
