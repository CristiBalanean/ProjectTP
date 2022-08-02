using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMain : AbstractCharacter
{

    private Animator animator;
    private Transform firPoint;
    private float angie;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        firPoint = GetComponent<Transform>().Find("FirePoint");
        angie = 0f;
        
    }

    public void OnMovement (InputAction.CallbackContext context) 
    {
        Debug.Log(context.phase);
        if(context.performed)
        {
            movement = context.ReadValue<Vector2>();

            if(movement.x != 0 || movement.y != 0)
            {
                Debug.Log("x:" + movement.x + ", y:" + movement.y);
                animator.SetFloat("X", movement.x);
                animator.SetFloat("Y", movement.y);

                animator.SetBool("IsWalking", true);
            } else {
                animator.SetBool("IsWalking", false);
            }
            //angie = 180f*(movement.y) + 180f*(-movement.y) - 90f*(0f-movement.x);
            angie = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;

            firPoint.transform.eulerAngles = new Vector3(firPoint.transform.eulerAngles.x, firPoint.transform.eulerAngles.y, angie);
            
            Debug.Log("Angle:" +  angie);
            /*
            180(y-1) - 90(0-x) 

            -180 down x:0 y:-1
            -90 right x:1 y:0
            -270 left x:-1 y:0
            0 top x:0 y:1
            */
            Debug.Log("Move");
        }
        else if (context.canceled)
        {
            movement = context.ReadValue<Vector2>();
            animator.SetBool("IsWalking", false);
            angie = 0f;
        }
    }

    
    public void onFire()
    {
        
        Debug.Log("Fire");
        /*PenButton press = value.Get<PenButton>;
        if(press.)
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        */
    }

    void onJump()
    {
        Debug.Log("Jump");
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * baseSpeed * Time.fixedDeltaTime);
        //firPoint.Rotate(0f,0f, angie , Space.Self);
    }
}
