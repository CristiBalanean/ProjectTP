using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private PlayerInput playerInput;

    private void Awake() 
    {
    }   

    public void onFire(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if(context.started)
        {
            Debug.Log("Fire");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

   

  
}
