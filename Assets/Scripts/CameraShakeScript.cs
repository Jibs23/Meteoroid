using UnityEngine;
using System.Collections;
using System.Collections.Generic;  
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraShakeScript : MonoBehaviour
{
    public static CameraShakeScript instance;
    [SerializeField] private float globalShakeForce = 1f;
    [SerializeField] private CinemachineImpulseListener ImpulseListener;
    private CinemachineImpulseDefinition ImpulseDefinition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
    public void ScreenShakeFromProfile(ScreenShakeProfile profile, CinemachineImpulseSource ImpulseSource)
    {
        // apply settings from profile
        SetupScreenShakeSettings(profile, ImpulseSource);
        // Screenshake
        ImpulseSource.GenerateImpulseWithForce(profile.ImpulseDuration);
        Debug.Log("ScreenShakeFromProfile");
    }
    private void SetupScreenShakeSettings(ScreenShakeProfile profile, CinemachineImpulseSource ImpulseSource)
    {
        ImpulseDefinition = ImpulseSource.m_ImpulseDefinition;

        // Change impulse source settings
        ImpulseDefinition.m_ImpulseDuration = profile.ImpulseDuration;
        ImpulseSource.m_DefaultVelocity = profile.defaultVelocity;
        ImpulseDefinition.m_CustomImpulseShape = profile.Implusecurve;

        // Change impulse listener settings
        ImpulseListener.m_ReactionSettings.m_AmplitudeGain = profile.ListenerAmplitide;
        ImpulseListener.m_ReactionSettings.m_FrequencyGain = profile.ListenerFrequency;
        ImpulseListener.m_ReactionSettings.m_Duration = profile.ListenerDuration;
    }
}
