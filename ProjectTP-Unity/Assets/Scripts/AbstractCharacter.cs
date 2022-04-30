using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AbstractCharacter : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int maxHp = 100;

    [Header("Movement")]
    [SerializeField] protected int speed = 5;
    protected Vector2 movement;
    protected Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        HealthCheck();
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    protected void HealthCheck()
    {
        if(hp > maxHp)
        {
            hp = maxHp;
        }
    }

    
}
