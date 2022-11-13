using Beans2022.PickUps;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject boosterPickUp1;
    [SerializeField] private GameObject boosterPickUp2;
    [SerializeField] private GameObject boosterPickUp3;
    [SerializeField] private GameObject boosterPickUp4;
    [SerializeField] private GameObject boosterPickUp5;


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
        PickUps.Add(boosterPickUp1);
        PickUps.Add(boosterPickUp2);
        PickUps.Add(boosterPickUp3);
        PickUps.Add(boosterPickUp4);
        PickUps.Add(boosterPickUp5);
    }

    private void Update()
    {
        if (!cooldownActive)
        {
            StartCoroutine(nameof(TickUpCooldown));
        }

        if (spawnReady)
        {
            randomPickUpIndex = Random.Range(0, 4);

            GameObject temp = PickUps[randomPickUpIndex];

            Instantiate(temp, new Vector3(100, Random.Range(1.3f,5.5f), 0),Quaternion.Euler(-90,0,-180));

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
