using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMain : AbstractCharacter
{

    private Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    private void OnMovement (InputValue value) {
        movement = value.Get<Vector2>();

        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
        
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * baseSpeed * Time.fixedDeltaTime);
    }
}
