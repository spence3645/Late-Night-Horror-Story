using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    Transform player;

    float sensitivity = 1000.0f;
    float rotationX = 0.0f;
    float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<CharacterController>().transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerMouse();
    }

    void GetPlayerMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        rotationX -= mouseY;
        rotationY -= mouseX;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        this.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
