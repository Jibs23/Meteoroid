using Unity.VisualScripting;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public int RotationSpeed;
    public int StartMoveSpeed;
    public LogicScript Logic;
    public float MinSpeed = 1500f;
    public float MaxSpeed = 4000f;
    void Start()
    {
        // Find components
        myRigidbody = GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
        // ADD RANDOM ROTATION
        myRigidbody.rotation = Random.Range(0, 360);
        RotationSpeed = Random.Range(850, 1250);
        if (Random.value > 0.5f) // Random.value returns a random float between 0 and 1
        {
            myRigidbody.AddTorque(RotationSpeed);
        }
        else
        {
            myRigidbody.AddTorque(-RotationSpeed);
        }
        
        // ADD RANDOM MOVEMENT
        StartMoveSpeed = Random.Range(3000, 4000);
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // Random.insideUnitCircle returns a random point inside the unit circle, normalized makes it a vector with a magnitude of 1
        myRigidbody.AddForce(randomDirection * StartMoveSpeed); // Add a force in the random direction

    }

    // Update is called once per frame
    void Update()
    {
        // If the speed of the object is less than the minimum speed
        if (myRigidbody.linearVelocity.magnitude < MinSpeed)
        {
            // Add a force in the direction of the velocity
            myRigidbody.AddForce(myRigidbody.linearVelocity.normalized);
        }
        if (myRigidbody.linearVelocity.magnitude > MaxSpeed)
        {
            // Add a force in the opposite direction of the velocity
            myRigidbody.AddForce(-myRigidbody.linearVelocity.normalized);
        }
    }
    void OnDrag()
    {
        // If the object is dragged
        // Set the position of the object to the position of the mouse
        transform.position = Input.mousePosition;
    }
}
