using UnityEngine;

public class OffScreenIndicatorScript : MonoBehaviour
{
    LogicScript Logic;
    PlayerScript Player;
    SpriteRenderer Arrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Player = GetComponentInParent<PlayerScript>();
        Arrow = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.IsOffScreen)
        {
            Arrow.enabled = true;
            int EdgeDistance =25;

            // Get the screen position of the player
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(Player.transform.position);

            // Clamp the screen position to the screen bounds
            screenPosition.x = Mathf.Clamp(screenPosition.x, 0 +EdgeDistance, Screen.width -EdgeDistance);
            screenPosition.y = Mathf.Clamp(screenPosition.y, 0 +EdgeDistance, Screen.height -EdgeDistance);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            // Set the position of the arrow to the clamped screen position
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);

            // Rotate the arrow to point towards the player gradually
            Vector3 direction = Player.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        }
        else
        {
            Arrow.enabled = false;
        }
    }
}
