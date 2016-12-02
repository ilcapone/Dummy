using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectEntronoView : MonoBehaviour {

    public Button CGI_Button;
    public Button ODV_Button;

    public void UpdateView(SelectEntornoData data)
    {
        CGI_Button.onClick.AddListener(data.CGI_ButtonAction);
        ODV_Button.onClick.AddListener(data.ODV_ButtonAction);
    }
}
