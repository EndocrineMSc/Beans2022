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
        string collisionName = collision.gameObject.name;

        if (collisionName.Contains("Player"))
        {
            StartCoroutine(GameManager.Instance.SlowDown());
            gameObject.GetComponent<Collider>().enabled = false;
            GameManager.Instance.GetComponent<AudioManager>().PlaySoundEffect(SFX.Moan1);
        }
        else if (collisionName.Contains("Slenderman"))
        { 
            Vector3 currentPosition = collision.gameObject.transform.position;

            collision.gameObject.transform.position = new Vector3 (currentPosition.y, currentPosition.x + 5, currentPosition.z);
        }
        else if(collisionName.Contains("Plattform"))
        {
            //do nothing
        }
        else
        {
            Vector3 currentPosition = collision.gameObject.transform.position;

            collision.gameObject.transform.position = new Vector3(currentPosition.y + 1, currentPosition.x, currentPosition.z);
        }
    }

    private void Update()
    {
        if(transform.position.x < -50f)
        {
            Destroy(gameObject);
        }
    }
}
