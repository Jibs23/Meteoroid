using UnityEngine;

public class RockLargeDeathScript : MonoBehaviour
{
    private HealthScript Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.IsDead)
        {
            Destroy(gameObject);
        }
    }
}
