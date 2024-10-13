using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PumpkinController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 10f;

    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void RotateDirection(){
        // Rotate pumpkin towards moving direction
        transform.Rotate(0,0,-moveDirection.x*rotationSpeed);
        transform.Rotate(0,0,-moveDirection.y*rotationSpeed);
    }
    void Update()
    {
        if(rb.velocity != Vector2.zero){
            moveDirection = rb.velocity;
            RotateDirection();
        }

        if (rb.velocity.magnitude > 1){
            if (!audioSource.isPlaying) {audioSource.Play();}
        } else {
            audioSource.Stop();
        }
    }
}
