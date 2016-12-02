using UnityEngine;
using System.Collections;



public class Parameters : MonoBehaviour
{
    private static Parameters instance = null;

    public string uri = "";
    public string ip = "";

    private Parameters()
    {
        instance = this;
    }

    public static Parameters GetInstance()
    {
        if (instance == null)
            instance = new Parameters();

        return instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            //GameObject.Find("Plano1").GetComponent<GstUnityBridgeTexture>().m_URI = uri;
            //GameObject.Find("Plano1").GetComponent<GstUnityBridgeTexture>().m_NetworkSynchronization.m_MasterClockAddress = ip;

           // GameObject.Find("Sphere1").GetComponent<GstUnityBridgeTexture>().m_URI = uri;
            //GameObject.Find("Sphere1").GetComponent<GstUnityBridgeTexture>().m_NetworkSynchronization.m_MasterClockAddress = ip;

            //GameObject.Find("Plano2").GetComponent<GstUnityBridgeTexture>().m_URI = uri;
            //GameObject.Find("Plano2").GetComponent<GstUnityBridgeTexture>().m_NetworkSynchronization.m_MasterClockAddress = ip;

            //GameObject.Find("Sphere2").GetComponent<GstUnityBridgeTexture>().m_URI = uri;
            //GameObject.Find("Sphere2").GetComponent<GstUnityBridgeTexture>().m_NetworkSynchronization.m_MasterClockAddress = ip;
        }
    }


}
