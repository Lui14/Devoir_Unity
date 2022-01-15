using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeBar : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    AIMover aimover;
    public float life = 100;
    public Animator shelteranim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        aimover = GetComponent<AIMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            anim.SetBool("Death", true);
            if (shelteranim != null)
            {
                shelteranim.SetTrigger("Death");
            }
            Destroy(rb);
            Destroy(gameObject, 5);
            if (aimover != null)
            {
                aimover.linearSpeed = 0;
                aimover.angularSpeed = 0;
            }
        }
    }
}
