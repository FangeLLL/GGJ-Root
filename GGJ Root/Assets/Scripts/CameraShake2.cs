using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake2 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;
    public bool bulletHitShake;
    public bool bulletKillShake;
    public bool swordHitShake;
    public bool swordKillShake;
    public bool shoot;

    public float b;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (bulletHitShake)
        {
            StartCoroutine(lerpzerohit());
            noise.m_AmplitudeGain = Mathf.Lerp(noise.m_AmplitudeGain, 0, b/40f);
            noise.m_FrequencyGain = Mathf.Lerp(noise.m_FrequencyGain, 0, b/40f);
            b += Time.deltaTime;
            if (noise.m_FrequencyGain == 0 && noise.m_AmplitudeGain == 0)
            {
                bulletHitShake = false;
            }
        }*/

        /*if (bulletKillShake)
        {
            StartCoroutine(lerpzerokill());
            noise.m_AmplitudeGain = Mathf.Lerp(noise.m_AmplitudeGain, 0, b / 40f);
            noise.m_FrequencyGain = Mathf.Lerp(noise.m_FrequencyGain, 0, b / 40f);
            b += Time.deltaTime;            
            if (noise.m_FrequencyGain == 0 && noise.m_AmplitudeGain == 0)
            {
                bulletKillShake = false;
            }
        }*/
        
        /*if (swordHitShake)
        {
            StartCoroutine(lerpzerohit());
            noise.m_AmplitudeGain = Mathf.Lerp(noise.m_AmplitudeGain, 0, b / 40f);
            noise.m_FrequencyGain = Mathf.Lerp(noise.m_FrequencyGain, 0, b / 40f);
            b += Time.deltaTime;
            if (noise.m_FrequencyGain == 0 && noise.m_AmplitudeGain == 0)
            {
                swordHitShake = false;
            }
        }

        if (swordKillShake)
        {
            StartCoroutine(lerpzerokill());
            noise.m_AmplitudeGain = Mathf.Lerp(noise.m_AmplitudeGain, 0, b / 40f);
            noise.m_FrequencyGain = Mathf.Lerp(noise.m_FrequencyGain, 0, b / 40f);
            b += Time.deltaTime;
            if (noise.m_FrequencyGain == 0 && noise.m_AmplitudeGain == 0)
            {
                swordKillShake = false;
            }
        }*/

        if (shoot)
        {
            StopAllCoroutines();
            StartCoroutine(lerpzerohit());
            noise.m_AmplitudeGain = Mathf.Lerp(noise.m_AmplitudeGain, 0, b / 40f);
            noise.m_FrequencyGain = Mathf.Lerp(noise.m_FrequencyGain, 0, b / 40f);
            b += Time.deltaTime;
            if (noise.m_FrequencyGain == 0 && noise.m_AmplitudeGain == 0)
            {
                shoot = false;
            }
        }
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
    }

    IEnumerator lerpzerohit()
    {
        yield return new WaitForSeconds(.8f);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
    /*IEnumerator lerpzerokill()
    {
        yield return new WaitForSeconds(.9f);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }*/

    /*IEnumerator lerpshoot()
    {
        yield return new WaitForSeconds(.3f);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }*/

}
