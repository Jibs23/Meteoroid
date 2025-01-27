using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public bool isGameOver = false;
    private int frames = 2;
    public float RightSideOfScreenInWorld;
    public float LeftSideOfScreenInWorld;
    public float TopOfScreenInWorld;
    public float BottomOfScreenInWorld;
    public Vector3 ScreenCenter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckScreenSize();
    }

    // Update is called once per frame
    void Update()
    {
        // Check screen size every 60 frames
        frames++;
        if (frames % 60 == 0)
        {
            CheckScreenSize();
        }
        if (isGameOver)
        {
            // If the game is over
            // Check if the player presses the R key
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                // Reload the scene
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }

    }
    void CheckScreenSize() // This function checks the size of the screen in world units
    {   
        // Get the right and left side of the screen in world units
        RightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        LeftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
        
        // Get the top and bottom of the screen in world units
        TopOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        BottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        // Get the center of the screen in world units
        ScreenCenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2)); // Get the center of the screen in world units
    }

}
