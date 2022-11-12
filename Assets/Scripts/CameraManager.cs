using Beans2022;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraManager : MonoBehaviour
{

    [SerializeField] CinemachineRecomposer cineRecomp;
    [SerializeField] CinemachineStoryboard cineSB;

    float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = GameManager.Instance.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //currentSpeed = GameManager.Instance.Speed;
        cineRecomp.m_ZoomScale = 1 + (startSpeed - GameManager.Instance.Speed) * 0.1f;

    }
}
