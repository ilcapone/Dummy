using UnityEngine;
using System.Collections;

public class ManagerGameController : modeloController
{
    ManagerGameData data;
    public ManagerGameView view;

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

    ManagerGameData GetData()
    {
        if (data == null)
        {
            data = new ManagerGameData();
        }

        return data;
    }

    void UpdateData(ref ManagerGameData data)
    {
        data.Back_ButtonAction = delegate { selectBack_Menu(); };
    }

    public void selectBack_Menu()
    {
        MenuManager.Manager.UpdateScene(MenuManager.Scene.Menu);
    }
    
}
