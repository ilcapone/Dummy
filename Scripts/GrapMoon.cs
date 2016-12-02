using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GrapMoon : MonoBehaviour {

    GameObject Moon;
    GameObject moonLight; // para poder modificar la intensidad de la luz como una posible abilidad
    float curretHealth;
    bool maxhelth = false;
    bool grabMoon = false;
    float d;

    // Use this for initialization
    void Start () {
       


    }
	
	// Update is called once per frame
	void Update () {


        Vector3 directionup = transform.TransformDirection(Vector3.up);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        //primero comprovamos si tiene una luna o no
        if (grabMoon == true)
        {
            //si ha cogido una luna, recupera vida

            if (maxhelth == false)
            {
                PlayerHealth PHealth = (PlayerHealth)this.GetComponent(typeof(PlayerHealth));
                PHealth.ChangeHelath(+0.1f);
                Debug.Log(PHealth.currentHealth + " , " + PHealth.getcurrentHealth());
                if (PHealth.currentHealth >= 100)
                {
                    maxhelth = true;
                }
            }

            //si tiene una luna refrescamos su posicion en funcion del user

            Moon.transform.position = transform.position + directionup.normalized * d;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                grabMoon = false;
                Moon.transform.position = new Vector3(Moon.transform.position.x, transform.position.y, Moon.transform.position.z);
            }


        }
        else
        {
            maxhelth = false;
            //si n ha cogido ninguna luna disminulle su vida
            PlayerHealth PHealth = (PlayerHealth)this.GetComponent(typeof(PlayerHealth));
            PHealth.ChangeHelath(-0.005f);

            //si n tiene luna gestionamos el evento para coger una luna
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, forward, out hit, 100f))
                {
                    d = hit.distance;

                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Star"))
                    {
                        //coges la luna
                        Moon = GameObject.Find(hit.transform.gameObject.name);
                        Moon.transform.position = transform.position + directionup.normalized * d;
                        grabMoon = true;

                    }
                }
            }

        }
    }

    public void DropMoon()
    {
        grabMoon = false;
        Moon = null;
    }
}
