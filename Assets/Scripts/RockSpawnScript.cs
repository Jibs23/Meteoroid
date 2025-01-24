using UnityEngine;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;

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

        // Ensure the spawn position is not too close to existing rocks
        bool positionIsValid = false;
        int attempts = 0;
        while (!positionIsValid && attempts < 10)
        {
            positionIsValid = true;
            foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Rock"))
            {
            if (UnityEngine.Vector2.Distance(rock.transform.position, spawnPosition) < screenWrap.ScreenWrapReapearBuffer)
            {
                positionIsValid = false;
                break;
            }
            }
            if (!positionIsValid)
            {
            // Randomly pick a new spawn position
            if (Random.value > 0.5f)
            {
                spawnPosition.x = Random.Range(Logic.LeftSideOfScreenInWorld, Logic.RightSideOfScreenInWorld + screenWrap.ScreenWrapReapearBuffer);
            }
            else
            {
                spawnPosition.y = Random.Range(Logic.BottomOfScreenInWorld, Logic.TopOfScreenInWorld + screenWrap.ScreenWrapReapearBuffer);
            }
            }
            attempts++;
        }

        // Spawn rock at specified position if valid
        if (positionIsValid)
        {
            Instantiate(LargeRock, spawnPosition, UnityEngine.Quaternion.identity); //quaternion.identity is the default rotation
            RockCount++;
        }
    }
}

