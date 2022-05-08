using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AbstractCharacter : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField, Min(0)] protected int hp = 100;
    [SerializeField, Min(1)] protected int maxHp = 100;
    [SerializeField] protected int strength = 10;
    [SerializeField] protected int  strengthMod = 0;
    [SerializeField, Min(0)] protected int mana = 100;
    [SerializeField, Min(1)] protected int maxMana = 100;


    [Header("Movement")]
    [SerializeField] protected int baseSpeed = 5;
    [SerializeField] protected int sprintSpeed = 10;
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
