using Beans2022;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraManager : MonoBehaviour
{

    [SerializeField] CinemachineRecomposer cineRecomp;
    [SerializeField] CinemachineStoryboard cineSB;
    public float blinkSpeed;
    public float closedTime;

    bool isBlinking = false;

    float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = GameManager.Instance.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        cineRecomp.m_ZoomScale = 1 + (startSpeed - GameManager.Instance.Speed) * 0.1f;
        if(Input.GetKeyDown(KeyCode.B) && !isBlinking)
        {
            Blink();
        }
    }
    void Blink()
    {
        isBlinking = true;
        StartCoroutine(blinkIn());
    }

    IEnumerator blinkIn()
    {
        
        while (cineSB.m_Alpha < 1)
        {
            cineSB.m_Alpha += 0.02f;
            cineSB.m_Scale.y -= 0.01f;
            yield return new WaitForSeconds(blinkSpeed * 0.02f);
        }
        StartCoroutine (waitBlinkClosing());
    }
    IEnumerator waitBlinkClosing()
    {
        int i = 0;
        while (i < closedTime * 50)
        {
            i++;
            cineSB.m_Scale.y -= 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(waitBlinkOpen());
    }
    IEnumerator waitBlinkOpen()
    {
        int i = 0;
        while (i < closedTime * 50)
        {
            i++;
            cineSB.m_Scale.y += 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(blinkOut());
    }
    IEnumerator blinkOut()
    {
        while (cineSB.m_Alpha > 0)
        {
            cineSB.m_Alpha -= 0.02f;
            cineSB.m_Scale.y += 0.01f;
            yield return new WaitForSeconds(blinkSpeed * 0.02f);
        }
        cineSB.m_Alpha = 0;
        cineSB.m_Scale.y = 2.2f;
        isBlinking = false;
    }
}
