using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public enum Entorno
    {
        none,
        PC,
        HTC
    };
    public enum Scene
    {
        none,
        Menu,
        PC_DummyMap,
        Inmersivo,
        World_Game
    };
    public enum UIPanelNavigation
    {
        PanelSelectDevice,
        PanelWin
    };

    Entorno goToEntorno = Entorno.PC;
    Scene goToScene = Scene.PC_DummyMap;
    modeloController currentController = null;

    // Use this for initialization
    private static MenuManager manager = null;
    public static MenuManager Manager
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
        }
      //  DontDestroyOnLoad(this.gameObject);
    }

    void PostAwake()
    {
       
        if (goToEntorno == Entorno.none)
        {
            goToEntorno = Entorno.PC;
        }

        Debug.Log("  POS Awake ");
        ResetViews();
    }

    void ResetViews()
    {
        this.gameObject.GetComponent<PanelSelectDeviceController>().Exit();
        //lo mismo para el PanelWinController
    }

    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SwitchPanel(UIPanelNavigation.PanelSelectDevice);
    }

    public void SwitchPanel(UIPanelNavigation nav)
    {
        if (currentController != null)
        {
            currentController.Exit();
            currentController.enabled = false;
        }

        switch (nav)
        {
            case UIPanelNavigation.PanelSelectDevice:
                {
                    currentController = this.gameObject.GetComponent<PanelSelectDeviceController>();
                    break;
                }
            case UIPanelNavigation.PanelWin:
                {
                    //currentController = this.gameObject.GetComponent<SelectInteractionCGIController>();
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

  
    public void UpdateScene(Scene newScene)
    {
        goToScene = newScene;
        GoScene();
    }

    private void GoScene()
    {
        switch (goToScene)
        {
            case Scene.Menu:
                {

                    SceneManager.LoadScene("Menu");
                    break;
                }
            case Scene.PC_DummyMap:
                {
                    SceneManager.LoadScene("DummyMap");
                    break;
                }
            case Scene.Inmersivo:
                {
                    SceneManager.LoadScene("DummyMap_HTC");
                    break;
                }
            case Scene.World_Game:
                {
                    SceneManager.LoadScene("DummyMap_Free");
                    break;
                }
        }
    }
    
}
