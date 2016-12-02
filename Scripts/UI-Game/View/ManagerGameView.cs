using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerGameView : MonoBehaviour {

    public Button Back_Button;

    public void UpdateView(ManagerGameData data)
    {
        Back_Button.onClick.AddListener(data.Back_ButtonAction);
    }
}
