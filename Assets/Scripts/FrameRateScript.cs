using UnityEngine;

public class FrameRateScript : MonoBehaviour
{
    public enum limits // Set the frame rate limit
    {
        LimitNone = 0,
        Limit30 = 30,
        Limit60 = 60,
        Limit120 = 120,
        Limit144 = 144,
    }
    public limits limit;

    void Awake()
    {
        Application.targetFrameRate = (int)limit; // Set the frame rate limit
    }
}
