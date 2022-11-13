using Beans2022;
using Cinemachine;
using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraManager : MonoBehaviour
{

    [SerializeField] CinemachineRecomposer cineRecomp;
    [SerializeField] CinemachinePostProcessing cinePost;
    public float blinkTime;
    public float blinkValue;
    public float oldDutch = 0f;
    public float dutch = 0f;

    int steps = 100;

    bool isBlinking = false;
    public bool changeDutch = false;

    float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = GameManager.Instance.Speed;
        PostProcessProfile profile = cinePost.m_Profile;
        Vignette vign;
        DepthOfField dof;
        profile.TryGetSettings(out vign);
        profile.TryGetSettings(out dof);
        vign.intensity.Override(0);
        dof.focusDistance.Override(5);
        cineRecomp.m_Dutch = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //cineRecomp.m_ZoomScale = 1 + (startSpeed - GameManager.Instance.Speed) * 0.1f;
        if(Input.GetKeyDown(KeyCode.B) && !isBlinking)
        {
            Blink();
        }
        if(dutch != cineRecomp.m_Dutch)
        {
            changeDutch = true;
            StartCoroutine(ChangeDutch());
        }
    }

    IEnumerator ChangeDutch()
    {
        if (cineRecomp.m_Dutch > dutch)
        {
            while(cineRecomp.m_Dutch > dutch)
            {
                cineRecomp.m_Dutch -= 0.005f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else {
            while (cineRecomp.m_Dutch < dutch)
            {
                cineRecomp.m_Dutch += 0.005f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        changeDutch = false;
        dutch = cineRecomp.m_Dutch;
    }

    public void Blink(float scale=1)
    {
        blinkTime = scale;
        if (!isBlinking)
        {
            StartCoroutine(StartBlink());
        }

    }
    IEnumerator StartBlink()
    {
        PostProcessProfile profile = cinePost.m_Profile;
        Vignette vign;
        DepthOfField dof;
        profile.TryGetSettings(out vign);
        profile.TryGetSettings(out dof);
        isBlinking = true;
        float valueStep = blinkValue * 1f / steps * blinkTime / 2f;
        float timeStep = (1f / steps) * (blinkTime / 3f);
        for (int i = 0; i < steps; i++)
        {
            dof.focusDistance.Override(5f - i * 4f / steps);
            vign.intensity.Override(vign.intensity + valueStep);
            yield return new WaitForSeconds(timeStep);
        }
        yield return new WaitForSeconds(blinkTime / 3);
        for (int i = 0; i < steps; i++)
        {
            dof.focusDistance.Override(1f + i * 4 / steps);
            vign.intensity.Override(vign.intensity - valueStep);
            yield return new WaitForSeconds(timeStep);
        }
        isBlinking = false;
        vign.intensity.Override(0);
        dof.focusDistance.Override(5f);
    }

}
