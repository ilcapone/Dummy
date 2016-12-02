using UnityEngine;
using System.Collections;

public class EnemyCharacter : MonoBehaviour {

    public int currentHealth;
    public int maxHealt = 100;

    public float leng;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealt;
        leng = Screen.width / 2;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnGUI()
    { // muestra vida del enemigo
        //GUI.Box(new Rect(10, 50, leng, 30), currentHealth + " / " + maxHealt);
    }

    public void ChangeHelath(int health)
    {
        currentHealth += health;
        leng = (Screen.width / 2) * (currentHealth / (float)maxHealt);
    }
}
