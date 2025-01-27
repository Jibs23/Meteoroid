using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource contactBulletSource;
    public AudioSource contactPlayerSource;
    public AudioSource lazerSource;
    public AudioSource playerDeathSource;
    public AudioSource rockDeathSource;
    public AudioSource thrusterSFXSource;

    public AudioClip contact_bullet, contact_player, Lazer, PlayerDeath, RockDeath, ThrusterSFX;

    public void PlayContactBullet()
    {
        RandomPitch(contactBulletSource);
        contactBulletSource.PlayOneShot(contact_bullet);
    }
    public void PlayContactPlayer()
    {
        RandomPitch(contactPlayerSource);
        contactPlayerSource.PlayOneShot(contact_player);
    }
    public void PlayLazer()
    {
        RandomPitch(lazerSource);
        lazerSource.PlayOneShot(Lazer);
    }
    public void PlayPlayerDeath()
    {
        RandomPitch(playerDeathSource);
        playerDeathSource.PlayOneShot(PlayerDeath);
    }
    public void PlayRockDeath()
    {
        RandomPitch(rockDeathSource);
        rockDeathSource.PlayOneShot(RockDeath);
    }

    private void RandomPitch(AudioSource source)
    {
        source.pitch = Random.Range(0.8f, 1.2f);
    }
}
