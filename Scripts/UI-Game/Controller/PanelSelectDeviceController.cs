using UnityEngine;
using System.Collections;

public class PanelSelectDeviceController : modeloController
{

    PanelSelectDeviceData data;
    public PanelSelectDeviceView view;

    public override void Init()
    {
        data = GetData();
        UpdateData(ref data);
        view.gameObject.SetActive(true);
        view.UpdateView(data);
    }

    public override void Exit()
    {
        view.gameObject.SetActive(false);
    }

    PanelSelectDeviceData GetData()
    {
        if (data == null)
        {
            data = new PanelSelectDeviceData();
        }

        return data;
    }
    void UpdateData(ref PanelSelectDeviceData data)
    {
        data.PC_ButtonAction = delegate { selectPC_game(); };
        data.HTC_ButtonAction = delegate { selectHTC_game(); };
        data.World_ButtonAction = delegate { selectWorld_game(); };
    }

    public void selectPC_game()
    {
        MenuManager.Manager.UpdateScene(MenuManager.Scene.PC_DummyMap);
    }
    public void selectHTC_game()
    {
        MenuManager.Manager.UpdateScene(MenuManager.Scene.Inmersivo);
    }
    public void selectWorld_game()
    {
        MenuManager.Manager.UpdateScene(MenuManager.Scene.World_Game);
    }
}
