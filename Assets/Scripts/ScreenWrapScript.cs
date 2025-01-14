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
    public float ScreenWrapLeeway = 1f;

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
        if (screenPosition.x <= -ScreenWrapLeeway && myRigidbody.linearVelocity.x < 0)
        {
            transform.position = new Vector2(Logic.RightSideOfScreenInWorld + ScreenWrapLeeway, transform.position.y);
        }
        else if (screenPosition.x >= Screen.width + ScreenWrapLeeway && myRigidbody.linearVelocity.x > 0)
        {
            transform.position = new Vector2(Logic.LeftSideOfScreenInWorld - ScreenWrapLeeway, transform.position.y);
        }

        // If object moves past top or bottom of screen
        if (screenPosition.y <= -ScreenWrapLeeway && myRigidbody.linearVelocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, Logic.TopOfScreenInWorld + ScreenWrapLeeway);
        }
        else if (screenPosition.y >= Screen.height + ScreenWrapLeeway && myRigidbody.linearVelocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, Logic.BottomOfScreenInWorld - ScreenWrapLeeway);
        }
    }
}
