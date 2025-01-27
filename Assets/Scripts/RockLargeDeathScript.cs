using UnityEngine;

public class RockLargeDeathScript : MonoBehaviour
{
    private HealthScript Health;
    private SoundManagerScript Sound;
    public RockSpawnScript RockSpawn;
    public ParticleSystem DeathExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = GetComponent<HealthScript>();
        RockSpawn = GameObject.FindGameObjectWithTag("Logic").GetComponent<RockSpawnScript>();
        Sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.IsDead)
        {
            Sound.PlayRockDeath();
            var DeathExplosionInstance = Instantiate(DeathExplosion, transform.position, transform.rotation);
            float explosionDuration = DeathExplosionInstance.main.duration;
            DeathExplosionInstance.Play();
            Destroy(DeathExplosionInstance.gameObject, explosionDuration);
            RockSpawn.RockCount--;
            Destroy(gameObject);
        }
    }
}
