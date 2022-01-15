using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;

    float XMouse = 0;
    float YMouse = 0;

    float Sensitivity = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        XMouse += Input.GetAxis("Mouse X") * Sensitivity;
        YMouse -= Input.GetAxis("Mouse Y") * Sensitivity;

        YMouse = Mathf.Clamp(YMouse, -90f, 90f);

        transform.localEulerAngles = new Vector3(YMouse, 0, 0);
        player.localEulerAngles = new Vector3(0, XMouse, 0);

    }
}
