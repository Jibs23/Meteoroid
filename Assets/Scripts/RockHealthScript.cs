using UnityEngine;

public class RockHealthScript : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Rock has died.");
        Destroy(gameObject);
    }
}
