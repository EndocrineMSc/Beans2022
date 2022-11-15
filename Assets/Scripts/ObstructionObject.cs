using Beans2022;
using Beans2022.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumCollection;

public class ObstructionObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            StartCoroutine(GameManager.Instance.SlowDown());
            gameObject.GetComponent<Collider>().enabled = false;
            GameManager.Instance.GetComponent<AudioManager>().PlaySoundEffect(SFX.Moan1);
        }
    }
}
