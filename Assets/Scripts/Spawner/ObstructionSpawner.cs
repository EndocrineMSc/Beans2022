using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject parkBench;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject grave;
    [SerializeField] private GameObject trashBin;

    private List<GameObject> spawnList = new List<GameObject>();

    private int randomObstructionIndex = 0;

    private int spawnCooldown;

    [SerializeField] private int spawnCooldownStart;
    private bool spawnReady;
    private bool cooldownActive;

    #endregion

    #region Private Functions

    private void Start()
    {
        spawnList.Add(parkBench);
        spawnList.Add(stone);
        spawnList.Add(grave);
        spawnList.Add(trashBin);
    }


    private void Update()
    {
        if (!cooldownActive)
        {
            StartCoroutine(nameof(TickUpCooldown));
        }

        if (spawnReady)
        {
            randomObstructionIndex = Random.Range(0, 4);


            GameObject temp = spawnList[randomObstructionIndex];

            Debug.Log(temp.name);
            if (temp.name.Contains("parkBench"))
            {
                Instantiate(temp, new Vector3(100, -3, 0), Quaternion.Euler(0,180,0));
            }
            else if (temp.name.Contains("stone"))
            {
                Instantiate(temp, new Vector3(100, -2.5f, 0), Quaternion.Euler(0, 90, 0));
            }
            else if (temp.name.Contains("grave"))
            {
                Instantiate(temp, new Vector3(100, -3f, 0), Quaternion.Euler(-90, 0, 180));
            }
            else
            {
                Instantiate(temp, new Vector3(100, -3f, 0), Quaternion.Euler(-90, 0, 0));
            }

            spawnCooldown = 0;
            spawnReady = false;
            cooldownActive = false;

            if (spawnCooldownStart > 3)
            {
                spawnCooldownStart--;
            }
        }
    }

    #endregion

    #region IEnumerator 
    
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
