using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public bool isGameOver = false;
    private int frames = 2;
    public float RightSideOfScreenInWorld;
    public float LeftSideOfScreenInWorld;
    public float TopOfScreenInWorld;
    public float BottomOfScreenInWorld;
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
    }
    void CheckScreenSize() // This function checks the size of the screen in world units
    {   
        // Get the right and left side of the screen in world units
        RightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        LeftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
        
        // Get the top and bottom of the screen in world units
        TopOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        BottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;
    }

}
