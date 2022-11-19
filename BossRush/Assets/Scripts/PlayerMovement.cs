using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody rb;
    public bool isGrounded;
    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * moveSpeed * movement.x);
        transform.Translate(new Vector2(0, 1) * Time.deltaTime * moveSpeed * movement.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Interagir");
        }
    }
}
