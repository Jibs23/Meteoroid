using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LogicScript Logic;
    public int MaxHealth = 3;
    public int CurrentHealth;
    public float invincibilityTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Logic.isGameOver = true;
        Destroy(gameObject);
    }
}
