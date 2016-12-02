using UnityEngine;
using System.Collections;
using System;

public class SelectInteractionCGIController : modeloController
{

    SelectInteractionCGIData data;
    public SelectInteracionCGIView view;

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

    SelectInteractionCGIData GetData()
    {
        if (data == null)
        {
            data = new SelectInteractionCGIData();
        }

        return data;
    }

    void UpdateData(ref SelectInteractionCGIData data)
    {
        data.Back_ButtonAction = delegate { BackButton(); };
        data.Gestos_CGI_ButtonAction = delegate { selectGestos_Scene(); };
        data.Voz_CGI_ButtonAction = delegate { selectVoz_Scene(); };
    }


    public void BackButton()
    {
        ApplicationManagerGame.Manager.SwitchPanel(ApplicationManagerGame.UIPanelNavigation.SelectEntorno);
    }
    public void selectGestos_Scene()
    {
        ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.CGI_Gestos);
    }
    public void selectVoz_Scene()
    {
       ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.CGI_Voz);
    }
    
}
