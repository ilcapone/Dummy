using UnityEngine;
using System.Collections;

public class EnemyAtackInmersive : MonoBehaviour {

    public float maxDistance;
    public float coolDownTimer;
    public PlayerHealthInmersive ph;
    public int damage;

    private Transform myTransform;
    public Transform target;

	// Use this for initialization
	void Start () {

        GameObject go = GameObject.Find("[CameraRig]/Camera (head)/Camera (eye)");
        target = go.transform;
        myTransform = transform;
        maxDistance = 1;
        coolDownTimer = 0;
        damage = -1;


        ph = (PlayerHealthInmersive)go.GetComponent(typeof(PlayerHealthInmersive));

    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, myTransform.position);
        if (distance < maxDistance)
        {
            Attack();
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer = coolDownTimer - Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
	
	}

    void Attack()
    {
        Vector3 dir = Vector3.Normalize(target.position - myTransform.position);
        float direction = Vector3.Dot(dir, transform.forward);

        //si estamos detras del enemigo n puede atacarnos

        if (direction > 0)
        {

            if (coolDownTimer == 0)
            {
                ph.ChangeHelath(damage);
                coolDownTimer = 2;
            }
        }
    }
}
