using UnityEngine;
using System.Linq;
using System.Numerics;

public class RockSpawnScript : MonoBehaviour
{
    public GameObject LargeRock;
    public LogicScript Logic;
    public int RockCount;
    public int DesiredRocks = 5;
    private ScreenWrapScript screenWrap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        RockCount = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None).Count(obj => obj.name == LargeRock.name);
        screenWrap = LargeRock.GetComponent<ScreenWrapScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RockCount < DesiredRocks)
        {
            SpawnLargeRock();
        }
    }
    public void SpawnLargeRock()
    {
        // Randomly pick a spawn position
        UnityEngine.Vector2 spawnPosition;

        // Randomly pick top or bottom
        if (Random.value > 0.5f)
        {
            spawnPosition.y = Logic.TopOfScreenInWorld - screenWrap.ScreenWrapReapearBuffer;
        }
        else
        {
            spawnPosition.y = Logic.BottomOfScreenInWorld - screenWrap.ScreenWrapReapearBuffer;
        }

        // Randomly pick left or right
        if (Random.value > 0.5f)
        {
            spawnPosition.x = Logic.RightSideOfScreenInWorld - screenWrap.ScreenWrapReapearBuffer;
        }
        else
        {
            spawnPosition.x = Logic.LeftSideOfScreenInWorld - screenWrap.ScreenWrapReapearBuffer;
        }

        // Spawn rock at specified position
        Instantiate(LargeRock, spawnPosition, UnityEngine.Quaternion.identity); //quaternion.identity is the default rotation
        RockCount++;
    }
}
