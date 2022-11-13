using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject observer;
    [SerializeField] private GameObject slenderMan;

    private List<GameObject> spawnList = new List<GameObject>();

    private int randomEnemy = 0;

    private int spawnCooldown;

    [SerializeField] private int spawnCooldownStart;
    private bool spawnReady;
    private bool cooldownActive;

    #endregion

    #region Private Functions

    // Start is called before the first frame update
    void Start()
    {
        spawnList.Add(observer);
        spawnList.Add(slenderMan);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cooldownActive)
        {
            StartCoroutine(nameof(TickUpCooldown));
        }

        if (spawnReady) 
        {
            randomEnemy = Random.Range(0, 2);

            GameObject temp = spawnList[randomEnemy];

            if (temp.name.Contains("observer"))
            {
                Instantiate(temp, new Vector3(100, 3, 0), Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                Instantiate(temp, new Vector3(100, -3, 0), Quaternion.Euler(0, 180, 0));
            }
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
