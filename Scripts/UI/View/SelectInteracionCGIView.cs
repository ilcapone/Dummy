using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectInteracionCGIView : MonoBehaviour {

    public Button Back_Button;
    public Button Gestos_Button;
    public Button Voz_Button;

    public void UpdateView(SelectInteractionCGIData data)
    {
        Back_Button.onClick.AddListener(data.Back_ButtonAction);
        Gestos_Button.onClick.AddListener(data.Gestos_CGI_ButtonAction);
        Voz_Button.onClick.AddListener(data.Voz_CGI_ButtonAction);
    }
}
