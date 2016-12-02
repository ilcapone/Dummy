using UnityEngine;
using System.Collections;

public class DestroyKatana : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            Destroy(col.gameObject);

        }
    }
}
