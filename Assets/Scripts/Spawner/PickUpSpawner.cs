using Beans2022.PickUps;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using EnumCollection;

public class PickUpSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject PickUp1;
    [SerializeField] private GameObject PickUp2;
    [SerializeField] private GameObject PickUp3;
    [SerializeField] private GameObject PickUp4;
    [SerializeField] private GameObject PickUp5;


    private List<GameObject> PickUps = new List<GameObject>();

    private int randomPickUpIndex = 0;

    private int spawnCooldown;
    [SerializeField] private int spawnCooldownStart;
    private bool spawnReady;
    private bool cooldownActive;

    #endregion

    #region Private Functions

    private void Start()
    {
        PickUps.Add(PickUp1);
        PickUps.Add(PickUp2);
        PickUps.Add(PickUp3);
        PickUps.Add(PickUp4);
        PickUps.Add(PickUp5);
    }

    private void Update()
    {
        if (!cooldownActive)
        {
            StartCoroutine(nameof(TickUpCooldown));
        }

        if (spawnReady)
        {
            randomPickUpIndex = Random.Range(0, 5);

            GameObject temp = PickUps[randomPickUpIndex];
            PickUp pickUp = temp.GetComponent<PickUp>();
            float randomX = Random.Range(90, 110);
            float randomY = Random.Range(1.3f, 5.5f);

            Debug.Log("PickUp Spawned");

            switch (pickUp.Type)
            {
                case PickUpType.Kaffee:
                    Instantiate(temp, new Vector3(randomX, randomY, 0), Quaternion.Euler(0, 0, 0));
                    break;

                case PickUpType.Kissen:
                    Instantiate(temp, new Vector3(randomX, randomY, 0), Quaternion.Euler(0, 0, 0));
                    break;

                case PickUpType.Bier:
                    Instantiate(temp, new Vector3(randomX, randomY, 0), Quaternion.Euler(0, 50, 0));
                    break;

                case PickUpType.ColaDose:
                    Instantiate(temp, new Vector3(randomX, randomY, 0), Quaternion.Euler(-90, 0, -180));
                    break;

                case PickUpType.ColaFlasche:
                    Instantiate(temp, new Vector3(randomX, randomY, 0), Quaternion.Euler(-90, 0, -180));
                    break;
            }

            spawnCooldown = 0;
            spawnReady = false;
            cooldownActive = false;
        }
    }

    #endregion

    #region IEnumerators

    private IEnumerator TickUpCooldown()
    {
        cooldownActive = true;
        while (spawnCooldown < spawnCooldownStart)
        {
            yield return new WaitForSeconds(1f);
            spawnCooldown++;
        }
        spawnReady = true;
    }


    #endregion

}
