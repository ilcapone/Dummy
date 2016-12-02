using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    [SerializeField]
    public Texture2D crosshair;
    // Use this for initialization
    void OnGUI()
    {
        float w = crosshair.width / 2;
        float h = crosshair.height / 2;
         Rect position = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);

        if (!Input.GetButton("Fire2"))
        {
            GUI.DrawTexture(position, crosshair);
        }
    }
}
