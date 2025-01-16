using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapScript: MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private LogicScript Logic;
    private float RightSideOfScreenInWorld;

    private float LeftSideOfScreenInWorld;

    private float TopOfScreenInWorld;

    private float BottomOfScreenInWorld;
    public float ScreenWrapReapearBuffer = 1f; // This is the buffer for when the object reappears off the screen
    public float ScreenWrapLateDepartureBuffer = 1f; // This is the buffer for when the object is considered to have left the screen. //* IN PIXELS

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
        }
        else if (screenPosition.x >= Screen.width + ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.x > 0) // If object moves past right side of screen
        {
            transform.position = new Vector2(Logic.LeftSideOfScreenInWorld - ScreenWrapReapearBuffer, transform.position.y);
        }

        // If object moves past top or bottom of screen
        if (screenPosition.y <= -ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.y < 0) // If object moves past bottom of screen
        {
            transform.position = new Vector2(transform.position.x, Logic.TopOfScreenInWorld + ScreenWrapReapearBuffer);
        }
        else if (screenPosition.y >= Screen.height + ScreenWrapLateDepartureBuffer && myRigidbody.linearVelocity.y > 0) // If object moves past top of screen
        {
            transform.position = new Vector2(transform.position.x, Logic.BottomOfScreenInWorld - ScreenWrapReapearBuffer);
        }
    }
}
