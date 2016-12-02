using UnityEngine;
using System.Collections;

public class ColisionDestroyKunai : MonoBehaviour {

    GameObject GameController;

    void Start()
    {
        GameController = GameObject.Find("GameController");
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            Destroy(col.gameObject);
        }
    }
}
