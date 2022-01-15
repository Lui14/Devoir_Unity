using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    public float linearSpeed = 10f;
    public float angularSpeed = 20f;

    private Transform player;

    public Vector3 dirPlayer;

    public float life = 100;

    public float puissance = 5f;

    public void Start()
    {
        GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
        player = goPlayer.transform;
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            dirPlayer = player.position - transform.position;
            dirPlayer = dirPlayer.normalized;

            float angle = Vector3.SignedAngle(dirPlayer,
                transform.forward,
                transform.up);

            if (angle > 4)
                rb.AddTorque(transform.up * -5);
            else if (angle < -4)
                rb.AddTorque(transform.up * 5);

            if (Mathf.Abs(angle) < 10 && rb.velocity.magnitude < 3)
            {
                rb.AddForce(transform.forward * 1500);
            }

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerLifeBar other = collision.gameObject.GetComponent<PlayerLifeBar>();
        if (other != null)
        {
            other.currentHealth -= puissance;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + dirPlayer);
    }

}