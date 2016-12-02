using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float currentHealth;
    public int maxHealt = 100;

    public float leng;

    public Texture BoxTexture;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealt;
        leng = Screen.width / 5;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth < 0)
        {
            //Death
            SceneManager.LoadScene("Menu");
        }

    }

    void OnGUI()
    {
        GUI.Box (new Rect(45,220,leng,25), currentHealth + " / " + maxHealt );
    }

    public void ChangeHelath (float health)
    {
        currentHealth += health;
        leng = (Screen.width / 5) * (currentHealth / (float)maxHealt);
    }


    public float getcurrentHealth()
    {
        return currentHealth;
    }

}
