using UnityEngine;
using System.Collections;
using System;

public class SelectInteractionODVController : modeloController
{
    SelectInteractionODVData data;
    public SelectInteractionODVView view;

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

    SelectInteractionODVData GetData()
    {
        if (data == null)
        {
            data = new SelectInteractionODVData();
        }

        return data;
    }

    void UpdateData(ref SelectInteractionODVData data)
    {
        data.Back_ButtonAction = delegate { BackButton(); };
        data.Gestos_ButtonAction = delegate { selectGestos_Scene(); };
        data.Voz_ButtonAction = delegate { selectVoz_Scene(); };
        data.Visual_ButtonAction = delegate { selectVisual_Scene(); };
        data.GF_ButtonAction = delegate { selectGF_Scene(); };
    }


    public void BackButton()
    {
        ApplicationManagerGame.Manager.SwitchPanel(ApplicationManagerGame.UIPanelNavigation.SelectEntorno);
    }
    public void selectGestos_Scene()
    {
        ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.ODV_Gestos);
    }
    public void selectVoz_Scene()
    {
        ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.ODV_Voz);
    }
    public void selectVisual_Scene()
    {
        ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.ODV_Visual);
    }        
    public void selectGF_Scene()
    {
        ApplicationManagerGame.Manager.UpdateDevice(ApplicationManagerGame.Scene.ODV_GF);
    }
}
