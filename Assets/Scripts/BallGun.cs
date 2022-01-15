using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGun : MonoBehaviour
{

    public Transform playerCam;
    public Transform objectToThrow;

    public float fireRate = 7f;
    private float nextTimeToFire = 2f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {

            Transform obj = GameObject.Instantiate<Transform>(objectToThrow);
            obj.position = playerCam.position + playerCam.forward ;
            obj.GetComponent<Rigidbody>().AddForce(playerCam.forward * 40, ForceMode.Impulse);
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

}
