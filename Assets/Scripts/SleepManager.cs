using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using EnumCollection;
using TMPro;

public class SleepManager : MonoBehaviour
{
    #region Fields

    private float maxTimer;
    private float blinkTimer;
    private bool timerOn;

    #endregion



    #region Private Functions

    // Start is called before the first frame update
    void Start()
    {
        maxTimer = GameManager.Instance.SleepTimer;
        blinkTimer = GameManager.Instance.BlinkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.SleepTimer -= Time.deltaTime;
        float percentage = GameManager.Instance.SleepTimer / maxTimer;
        float blinkScaling = 1f;
        float dutch = 0f;

        /*if (!timerOn)
        {
            StartCoroutine(nameof(SleepCountdown));
        }*/
        if(percentage > 0.7f)
        {
            blinkScaling = 1f;
            dutch = 0f;
        }
        else if(percentage > 0.3f && percentage < 0.7f)
        {
            blinkScaling = 1f;
            dutch = 0f;
        }
        else
        {
            blinkScaling = 2f;
            dutch = Random.Range(-10f, 10f);

        }
        if (GameManager.Instance.SleepTimer < 0)
        {
            GameManager.Instance.SwitchState(GameState.GameOver);
        }
        GameManager.Instance.BlinkTimer -= Time.deltaTime * blinkScaling;
        if (!GameManager.Instance.GetComponent<CameraManager>().changeDutch)
        {
            GameManager.Instance.GetComponent<CameraManager>().dutch = dutch;
        }

        if(GameManager.Instance.BlinkTimer < 0)
        {
            GameManager.Instance.BlinkTimer = blinkTimer;
            gameObject.GetComponent<CameraManager>().Blink(blinkScaling);
            
        }
    }
    #endregion


    #region IEnumerators

    private IEnumerator SleepCountdown()
    {
        timerOn = true;
        yield return new WaitForSeconds(1);
        GameManager.Instance.SleepTimer -= 1;
        timerOn = false;
    }



    #endregion

}
