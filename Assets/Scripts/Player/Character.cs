using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterController controller;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();

        Movement();
    }

    void Movement()
    {
        float lr = Input.GetAxis("Horizontal");
        float fb = Input.GetAxis("Vertical");

        Vector3 movement = fb * this.transform.forward + lr * this.transform.right;

        controller.Move(movement * speed * Time.deltaTime);
    }

    void Gravity()
    {
        Vector3 gravVector = Vector3.zero;

        gravVector += Physics.gravity;

        controller.Move(gravVector * Time.deltaTime);
    }
}
