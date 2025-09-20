using UnityEngine;
using System.Collections;
using Cinemachine;

public class ScreenShake : Singleton<ScreenShake>
{
    [Header("Default Shake Settings")]
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float magnitude = 0.05f;
    [SerializeField] private float frequency = 2f;

    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private GameObject volume; 

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        if (vcam == null) vcam = FindObjectOfType<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void StartShake()
    {
        StartCoroutine(Shake(duration, magnitude, frequency));
        if (volume != null) StartCoroutine(Volume(0.1f));
    }

    public void StartShake(float customDuration, float customMagnitude, float customFrequency = 2f)
    {
        StartCoroutine(Shake(customDuration, customMagnitude, customFrequency));
        if (volume != null) StartCoroutine(Volume(customDuration));
    }

    private IEnumerator Shake(float duration, float magnitude, float frequency)
    {
        noise.m_AmplitudeGain = magnitude;
        noise.m_FrequencyGain = frequency;

        yield return new WaitForSeconds(duration);

        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

    private IEnumerator Volume(float effectDuration)
    {
        volume.SetActive(true);
        yield return new WaitForSeconds(effectDuration);
        volume.SetActive(false);
    }
}
