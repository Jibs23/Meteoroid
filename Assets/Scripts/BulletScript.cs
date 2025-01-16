using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D myRigidbody;
    public int BulletDamage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody.linearVelocity = transform.up * bulletSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bullet hit " + other.gameObject.name);
        try
        {
            HealthScript EntityHealth = other.gameObject.GetComponent<HealthScript>();
            if (EntityHealth != null)
            {
                EntityHealth.takeDamage(BulletDamage);
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("Bullet hit " +  other.gameObject.name + " which does not have a HealthScript");
        }
        
        //* DEATH
        Destroy(gameObject);

    }
}
