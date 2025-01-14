using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public int RotationSpeed;
    public int StartMoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ADD RANDOM ROTATION
        myRigidbody.rotation = Random.Range(0, 360);
        RotationSpeed = Random.Range(30, 100);
        if (Random.value > 0.5f) // Random.value returns a random float between 0 and 1
        {
            myRigidbody.AddTorque(RotationSpeed);
        }
        else
        {
            myRigidbody.AddTorque(-RotationSpeed);
        }
        
        // ADD RANDOM MOVEMENT
        StartMoveSpeed = Random.Range(0, 100);
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // Random.insideUnitCircle returns a random point inside the unit circle, normalized makes it a vector with a magnitude of 1
        myRigidbody.AddForce(randomDirection * StartMoveSpeed); // Add a force in the random direction

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
