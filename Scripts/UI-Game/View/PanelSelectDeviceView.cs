using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelSelectDeviceView : MonoBehaviour {

    public Button PC_Button;
    public Button HTC_Button;
    public Button Wordld_Button;

    public void UpdateView(PanelSelectDeviceData data)
    {
        PC_Button.onClick.AddListener(data.PC_ButtonAction);
        HTC_Button.onClick.AddListener(data.HTC_ButtonAction);
        Wordld_Button.onClick.AddListener(data.World_ButtonAction);
    }
}
