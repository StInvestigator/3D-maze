using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0F;
    [SerializeField] private float damage = 10.0F;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (!player.IsUnityNull())
        {
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}