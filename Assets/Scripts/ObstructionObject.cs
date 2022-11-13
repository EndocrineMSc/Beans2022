using Beans2022;
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
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
