using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "ScreenShakeProfile")]

public class ScreenShakeProfile : ScriptableObject
{
    [Header("Impulse Source Settings")]
    public float ImpulseDuration = 0.2f;
    public float ImpactForce = 1.0f;
    public Vector3 defaultVelocity = new Vector3(0f, -1f, 0f);
    public AnimationCurve Implusecurve;

    [Header("Impusle listener settings")]
    public float ListenerAmplitide = 1f;
    public float ListenerFrequency = 1f;
    public float ListenerDuration = 1f;
}
