using Cinemachine;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private ScreenShakeProfile screenShakeProfile_dammage;
    [SerializeField] private ScreenShakeProfile screenShakeProfile_die;
    private CinemachineImpulseSource ImpulseSource;
    public Camera MainCamera;
    public float MaxHealth = 1f;
    public float CurrentHealth;
    public bool isInvinsible = false;
    public bool IsDead { get { return CurrentHealth <= 0; } } // This is a property that returns true if the CurrentHealth is less than or equal to 0
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        MainCamera = Camera.main;
        try //Impulse source getter
        {
            ImpulseSource = GetComponent<CinemachineImpulseSource>();
        }
        catch
        {
            Debug.LogWarning("No CinemachineImpulseSource found on " + gameObject.name);
        }
    }
    public void takeDamage(float damage)
    {
        if (!isInvinsible)
        {
            CurrentHealth -= damage;
            CameraShakeScript.instance.ScreenShakeFromProfile(screenShakeProfile_dammage, ImpulseSource);
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " destroyed");
        CameraShakeScript.instance.ScreenShakeFromProfile(screenShakeProfile_die, ImpulseSource);
        Destroy(gameObject);
    }
}
