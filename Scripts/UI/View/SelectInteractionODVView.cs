using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectInteractionODVView : MonoBehaviour {

    public Button Back_Button;
    public Button Gestos_Button;
    public Button Voz_Button;
    public Button Vision_Button;
    public Button GF_Button;

    public void UpdateView(SelectInteractionODVData data)
    {
        Back_Button.onClick.AddListener(data.Back_ButtonAction);
        Gestos_Button.onClick.AddListener(data.Gestos_ButtonAction);
        Voz_Button.onClick.AddListener(data.Voz_ButtonAction);
        Vision_Button.onClick.AddListener(data.Visual_ButtonAction);
        GF_Button.onClick.AddListener(data.GF_ButtonAction);
    }
}
