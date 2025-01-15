using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float MaxHealth = 1f;
    public float CurrentHealth;
    public bool IsDead { get { return CurrentHealth <= 0; } } // This is a property that returns true if the CurrentHealth is less than or equal to 0
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void takeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    void Die()
    {
        Debug.Log(gameObject.name + " destroyed");
        Destroy(gameObject);
    }
}
