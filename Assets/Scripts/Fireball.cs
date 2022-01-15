using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour

{
    SpawnKillCounter killCounterScript;

    public float puissance = 50;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
        killCounterScript = GameObject.Find("killCounterObject").GetComponent<SpawnKillCounter>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        AIMover other = collision.gameObject.GetComponent<AIMover>();
        if (other != null)
        {
            other.life -= puissance;
            Destroy(gameObject); 

            if (other.life <= 0)
                Destroy(other.gameObject);
        }

        AISpawner spawner = collision.gameObject.GetComponent<AISpawner>();
        if (spawner != null)
        {
            spawner.health -= puissance;
            Destroy(gameObject);

            if (spawner.health <= 0)
            {
                killCounterScript.Addkill();
                Destroy(spawner.gameObject);
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }




}
