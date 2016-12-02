using UnityEngine;

public class SelectEntornoController : modeloController
{
    SelectEntornoData data;
    public SelectEntronoView view;

    public  override void Init()
    {
        data = GetData();
        UpdateData(ref data);
        view.gameObject.SetActive(true);
        view.UpdateView(data);
    }

    public  override void Exit()
    {
        view.gameObject.SetActive(false);
    }

    SelectEntornoData GetData()
    {
        if (data == null)
        {
            data = new SelectEntornoData();
        }

        return data;
    }

    void UpdateData(ref SelectEntornoData data)
    {
        data.CGI_ButtonAction = delegate { selectCGI_Entorno(); };
        data.ODV_ButtonAction = delegate { selectODV_Entorno(); };
    }

    public void selectCGI_Entorno()
    {
        ApplicationManagerGame.Manager.SwitchPanel(ApplicationManagerGame.UIPanelNavigation.SelectInteraction_CGI);
    }
    public void selectODV_Entorno()
    {
        ApplicationManagerGame.Manager.SwitchPanel(ApplicationManagerGame.UIPanelNavigation.SelectInteraction_ODV);
    }

}

    
