using Beans2022;
using Beans2022.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            StartCoroutine(GameManager.Instance.SlowDown());
            GameManager.Instance.GetComponent<AudioManager>().PlayCollision();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
