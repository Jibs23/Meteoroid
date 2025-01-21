using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapScript: MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private LogicScript Logic;
    public float ScreenWrapReapearBuffer = 1f; // This is the buffer for when the object reappears off the screen
    public float ScreenWrapLateDepartureBuffer = 1f; // This is the buffer for when the object is considered to have left the screen. //* IN PIXELS
    public float timeOutOfScreen = 0f;
    public float maxTimeOutOfScreen = 2f; // Time in seconds before the object is pushed back to the screen

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    void Update()
    {
        // Get the screen position of the object (in pixels).
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // If object moves past left or right side of screen
        if (screenPosition.x <= -ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.x < 0) // If object moves past left side of screen
        {
            transform.position = new Vector2(Logic.RightSideOfScreenInWorld + ScreenWrapReapearBuffer, transform.position.y);
            FindSuitableWrapPosition(transform.position);
        }
        else if (screenPosition.x >= Screen.width + ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.x > 0) // If object moves past right side of screen
        {
            transform.position = new Vector2(Logic.LeftSideOfScreenInWorld - ScreenWrapReapearBuffer, transform.position.y);
            FindSuitableWrapPosition(transform.position);
        }

        // If object moves past top or bottom of screen
        if (screenPosition.y <= -ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.y < 0) // If object moves past bottom of screen
        {
            transform.position = new Vector2(transform.position.x, Logic.TopOfScreenInWorld + ScreenWrapReapearBuffer);
            FindSuitableWrapPosition(transform.position);
        }
        else if (screenPosition.y >= Screen.height + ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.y > 0) // If object moves past top of screen
        {
            transform.position = new Vector2(transform.position.x, Logic.BottomOfScreenInWorld - ScreenWrapReapearBuffer);
            FindSuitableWrapPosition(transform.position);
        }
        
    }
  
    private Vector2 FindSuitableWrapPosition(Vector2 initialPosition) //? I Think this works, but I'm not acutally sure.
    {
        Vector2 spawnPosition = initialPosition;
        bool positionIsValid = false;
        int attempts = 0;

        while (!positionIsValid && attempts < 10)
        {
            positionIsValid = true;
            foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Rock"))
            {
                if (Vector2.Distance(rock.transform.position, spawnPosition) < ScreenWrapReapearBuffer)
                {
                    positionIsValid = false;
                    spawnPosition = new Vector2( // Set the spawn position to a new random position
                        spawnPosition.x + Random.Range(-ScreenWrapReapearBuffer*2, ScreenWrapReapearBuffer*2), 
                        spawnPosition.y + Random.Range(-ScreenWrapReapearBuffer*2, ScreenWrapReapearBuffer*2)
                    );
                    break; // Break out of the foreach loop
                }
            }
            attempts++;
        }
        return spawnPosition; // Return the spawn position
    }
}
