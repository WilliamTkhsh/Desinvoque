using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject enemy;
    public bool gameLost;
    private Rigidbody rb;
    public AudioSource StepSound;
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

        // Som dos passos
        if (movement.magnitude > 0.5f) playSteps();
        else StepSound.Stop();
    }

    void playSteps()
    {
        if(StepSound.isPlaying) return;
        StepSound.Play();
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            gameLost = true;
            moveSpeed = 0;
            Destroy(enemy);
        }

    }
}
