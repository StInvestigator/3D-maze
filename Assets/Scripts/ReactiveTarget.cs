using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
    public bool isDead = false;

    private Renderer _renderer;

    public float ReactOnHit(float damage)
    {
        if (isDead)
        {
            return currentHealth;
        }
        currentHealth -= damage;
        UpdateColor();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            StartCoroutine(Die());
        }
        return currentHealth;
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
        currentHealth = maxHealth;
        _renderer = GetComponent<Renderer>();
    }

    private void UpdateColor()
    {
        float healthPercentage = currentHealth / maxHealth;
        Color currentColor = Color.Lerp(Color.red, Color.white, healthPercentage);
        _renderer.material.color = currentColor;
    }
}
