using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Main : MonoBehaviour {

    int contadorButton = 0; // contador del numero de botones
    int d = 0;
    InputField input; //texto de entrada
    InputField.SubmitEvent se; //evento de enter nueva ip
    public Transform brick; //prefab de butpn IP
    public Transform brickDelete; //prefab de button delete
    public string IP;

    void Update () {
	
	}
    
    void Start()
    {
        input = gameObject.GetComponent<InputField>(); //asignacion del gameobjeto inputfile
        se = new InputField.SubmitEvent(); //asignacion del evento
        se.AddListener(SubmitInput); //se mantiene escuchando, para lanzar la funcion SubmitInput cuand se pulse el enter
        input.onEndEdit = se;
        getIPs();
    }

    void createButton(string ip)
    {
        if (contadorButton<1) {

            Transform t = Instantiate(brick, new Vector3(0, d, 0), Quaternion.identity) as Transform; //crea una nueva instancia del prefab de boton variando la posicion de 'y'
            GameObject go = t.gameObject; // se asigna la instancia a un nuevo objeto
            go.name = "Prefab_" + ip; // cambio nobre del nuevo prefab
            go.transform.GetChild(0).transform.name = "Button_" + ip; //cambio del nombre del boton dentro del prefab
            go.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = ip; //cambio del texto del boton q se mostrara en pantalla

            UnityEngine.UI.Button btn = go.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => chargeScene(ip));

            d = d + 35;
            contadorButton++;

        }
    }

    public void SubmitInput(string arg0)
    {
        string newText = arg0; //recogida de los datos del inputfile
        input.text = ""; //vaciado del inputfile
        DeleteButton("Prefab_" + IP);
        createButton(newText); //creacion de un nuevo botton con la nueva ip introducia
        IP = newText;
        setIP(newText);
    }
   
    public void chargeScene(string ip)
    {
        Debug.Log("IP: " + ip);
        Parameters s = Parameters.GetInstance();
        s.uri = "rtsp://" + ip + ":8554/test";
        s.ip = ip;
        SceneManager.LoadScene(1);//Carga la escena con idencificador (ID) este se asigna en Build Settings

    }

    public void DeleteButton(string button_ip)
    {
        PlayerPrefs.DeleteAll();
        Destroy(GameObject.Find(button_ip));
        contadorButton = 0;
        d = 0;
    }

    public void getIPs()
    {
       
        int n = 0;
        string ip;
        ip = PlayerPrefs.GetString("IP" + n);
        while (ip != "")
        {
            createButton(ip);
            IP = ip;
            n++;
            ip = PlayerPrefs.GetString("IP" + n);
        }
    }

    public void setIP(string newip)
    {
        int n = 0;
        string ip = "";
        while ((ip = PlayerPrefs.GetString("IP" + n)) != "")
        {
            n++;
        }
        PlayerPrefs.SetString("IP" + n, newip);
    }

}
