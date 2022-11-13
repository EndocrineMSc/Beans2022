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
    }
    
        
    

    private void Update()
    {
        if (!cooldownActive)
        {
            StartCoroutine(nameof(TickUpCooldown));
        }

        if (spawnReady)
        {
            //randomPickUpIndex = Random.Range(0, PickUps.Length-1);
            //Debug.Log(randomPickUpIndex);

            GameObject temp = PickUps[randomPickUpIndex];

            Instantiate(temp, new Vector3(100, 1.75f, 0),Quaternion.identity);

            spawnCooldown = 0;
            spawnReady = false;
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
