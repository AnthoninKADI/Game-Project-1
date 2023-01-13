using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakes : MonoBehaviour
{
    public static CameraShakes Instance { get; private set; }
    private float shakeTimer;
    private CinemachineVirtualCamera cinemachinevirtualcamera;
    private float startingIntensity;
    private float shakeTimerTotal;

    private void Awake()
    {
        Instance = this;
        cinemachinevirtualcamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachinevirtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachinevirtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, (1-(shakeTimer / shakeTimerTotal)));

            
        }
       
    }
}
