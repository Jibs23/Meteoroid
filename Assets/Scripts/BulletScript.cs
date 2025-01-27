using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D myRigidbody;
    public ParticleSystem ImpactParticles;
    public SoundManagerScript Sound;
    public int BulletDamage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody.linearVelocity = transform.up * bulletSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        try
        {
            Debug.Log("Bullet hit " + other.gameObject.name);
            HealthScript EntityHealth = other.gameObject.GetComponent<HealthScript>();
            if (EntityHealth != null)
            {
                EntityHealth.takeDamage(BulletDamage);
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("No HealthScript found on " + other.gameObject.name);
        }
        
        //* DEATH
        var impactParticlesInstance = Instantiate(ImpactParticles, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 180));
        impactParticlesInstance.Play();
        Sound.PlayContactBullet();

        Destroy(gameObject);
        Destroy(impactParticlesInstance.gameObject, impactParticlesInstance.main.duration);

    }
}
