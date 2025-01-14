using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float rotationSpeed = 1250f;
    public float bulletCooldown = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // move forward
        {
            myRigidbody.AddForce(transform.up * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D)) // turn right
        {
            myRigidbody.AddTorque(-rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // turn left
        {
            myRigidbody.AddTorque(rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space)) // Shoot
        {
            // Call the Shoot method
            Shoot();
        }
    }


    private float lastShotTime = 0f;
    void Shoot()
    {
        if (Time.time > lastShotTime + bulletCooldown) // Check if enough time has passed since the last shot by comparing the current time to the last shot time plus the cooldown
        {
            // Create a new bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            
            // Orient the bullet in the same direction as the rigid body
            bullet.transform.rotation = myRigidbody.transform.rotation;

            // Update the last shot time
            lastShotTime = Time.time;
        }
    }
}
