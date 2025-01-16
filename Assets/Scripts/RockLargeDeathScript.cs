using UnityEngine;

public class RockLargeDeathScript : MonoBehaviour
{
    private HealthScript Health;
    public RockSpawnScript RockSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = GetComponent<HealthScript>();
        RockSpawn = GameObject.FindGameObjectWithTag("Logic").GetComponent<RockSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.IsDead)
        {
            RockSpawn.RockCount--;
            Destroy(gameObject);
        }
    }
}
