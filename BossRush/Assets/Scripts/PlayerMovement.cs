using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public float jumpForce;
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
        movement.z = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed * movement.x);
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed * movement.z);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Interagir");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Background")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Background")
        {
            isGrounded = false;
        }
    }
}
