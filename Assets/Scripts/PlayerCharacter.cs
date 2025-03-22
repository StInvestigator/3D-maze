using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPSInput))]
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private FPSInput movement;

    void Start()
    {
        movement = GetComponent<FPSInput>();
    }

    public void Hurt(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 100.0F;
            Debug.Log("Player is dead");
        }

        if (damage > 0)
        {
            StartCoroutine(movement.ReduceSpeedTemporarily(3f, 2f));
        }
    }

   
}