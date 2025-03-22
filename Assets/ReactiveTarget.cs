using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float lifeLevel = 100;
    public bool isDead = false;

    public float ReactOnHit(float damage)
    {
        if (isDead)
        {
            return lifeLevel;
        }
        lifeLevel -= damage;
        if (lifeLevel <= 0)
        {
            lifeLevel = 0;
            StartCoroutine(Die());
        }
        return lifeLevel;
    }

    private IEnumerator Die()
    {
            transform.Rotate(-90, 0, 0);
            transform.Translate(0, 0, -1.0f);
            isDead = true;
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
