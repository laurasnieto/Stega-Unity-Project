using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed,
               turnSpeed;

    float h,
          v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Movement();
        Rotate();
    }

    void InputPlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * h * turnSpeed * Time.deltaTime);
    }

}
