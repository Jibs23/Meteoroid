using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private ScreenShakeProfile screenShakeProfile;
    private CinemachineImpulseSource ImpulseSource;
    public Camera MainCamera;
    public float MaxHealth = 1f;
    public float CurrentHealth;
    public bool IsDead { get { return CurrentHealth <= 0; } } // This is a property that returns true if the CurrentHealth is less than or equal to 0
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        MainCamera = Camera.main;
        ImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void takeDamage(float damage)
    {
        CurrentHealth -= damage;
        CameraShakeScript.instance.ScreenShakeFromProfile(screenShakeProfile, ImpulseSource);
    }

    void Die()
    {
        Debug.Log(gameObject.name + " destroyed");

        Destroy(gameObject);
    }
}
