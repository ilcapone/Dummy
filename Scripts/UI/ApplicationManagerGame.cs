using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManagerGame : MonoBehaviour {

    public enum Entorno {
        none,
        ODV
    };

    public enum Interacion
    {
        none,
        gestos,
        voz,
        visual,
        gf
    };

    public enum Device
    {
        none,
        PC,
        HTC_Kinect,
        HTC_Leap,
        SamsungGear,
        CardBoard
    };

    public enum Scene
    {
        CGI_Gestos,
        CGI_Voz,
        ODV_Gestos,
        ODV_Voz,
        ODV_Visual,
        ODV_GF
    };

    public enum UIPanelNavigation {
        SelectEntorno,
        SelectInteraction_CGI,
        SelectInteraction_ODV,
        SelectDevice_ODV

    };

    Entorno goToEntorno = Entorno.ODV;
    Device goToDevice = Device.PC;
    Interacion gotoInteraction = Interacion.gestos;
    Scene goToScene = Scene.CGI_Gestos;

    modeloController currentController = null;

    private static ApplicationManagerGame manager = null;
    public static ApplicationManagerGame Manager
    {
        get { return manager; }
    }

    void Awake()
    {
        GetThisManager();
    }

    void GetThisManager()
    {
        if (manager != null && manager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            manager = this;
            PostAwake();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void PostAwake()
    {
        if (goToDevice == Device.none)
        {
            goToDevice = Device.HTC_Kinect;
        }

        if (gotoInteraction == Interacion.none)
        {
            gotoInteraction = Interacion.gestos;
        }

        if (goToEntorno == Entorno.none)
        {
            goToEntorno = Entorno.ODV;
        }

        ResetViews();
    }

    void Start()
    {
        SwitchPanel(UIPanelNavigation.SelectEntorno);
    }

    void ResetViews()
    {
        this.gameObject.GetComponent<SelectEntornoController>().Exit();
        this.gameObject.GetComponent<SelectInteractionODVController>().Exit();
        this.gameObject.GetComponent<SelectInteractionCGIController>().Exit();
    }

    public void SwitchPanel( UIPanelNavigation nav)
    {
        if (currentController != null)
        {
            currentController.Exit();
            currentController.enabled = false;
        }

        switch (nav)
        {
            case UIPanelNavigation.SelectEntorno:
                {
                    currentController = this.gameObject.GetComponent<SelectEntornoController>();
                    break;
                }
            case UIPanelNavigation.SelectInteraction_CGI:
                {
                   currentController = this.gameObject.GetComponent<SelectInteractionCGIController>();
                    break;
                }
            case UIPanelNavigation.SelectInteraction_ODV:
                {
                     currentController = this.gameObject.GetComponent<SelectInteractionODVController>();
                    break;
                }
        }

        if (currentController)
        {
            currentController.enabled = true;
            currentController.Init();
        }
        else
        {
            Debug.LogError("No hay ningun controlador asignado");
        }
    }

    
    public void UpdateDevice(Scene newScene)
    {
        goToScene = newScene;
        GoToEntorno();
    }

    private void GoToEntorno()
    {
        switch (goToScene)
        {
            case Scene.CGI_Gestos:
                {
                    SceneManager.LoadScene("CGI_Gestos");
                    break;
                }
            case Scene.CGI_Voz:
                {
                    SceneManager.LoadScene("CGI_Voz");
                    break;
                }
            case Scene.ODV_Gestos:
                {
                    SceneManager.LoadScene("ODV_Gestos");
                    break;
                }
            case Scene.ODV_Voz:
                {
                    SceneManager.LoadScene("ODV_Voz");
                    break;
                }
            case Scene.ODV_Visual:
                {
                    SceneManager.LoadScene("ODV_Visual");
                    break;
                }
            case Scene.ODV_GF:
                {
                    SceneManager.LoadScene("ODV_GF");
                    break;
                }
        }
    }

}
