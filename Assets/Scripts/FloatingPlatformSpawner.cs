using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private FloatingPlatform _floatingPlatform;

    private int _randomSpawnTime;
    private int _randomSpawnAmount;
    private bool _onCooldown;

    #endregion

    #region Private Functions

    // Update is called once per frame
    void Update()
    {
        if (!_onCooldown)
        {
            _randomSpawnTime = Random.Range(2, 10);
            _randomSpawnAmount = Random.Range(1, 4);

            StartCoroutine(nameof(SpawnPlatforms));
        }

    }

    #endregion

    #region IEnumerators

    private IEnumerator SpawnPlatforms()
    {
        _onCooldown = true;
        yield return new WaitForSeconds(_randomSpawnTime);
        
        for (int i = 0; i < _randomSpawnAmount; i++) 
        {
            Instantiate(_floatingPlatform, new Vector3(50 + (i * 6.5f), 2, 0), Quaternion.Euler(-90, 90, 180));        
        }

        _onCooldown= false;
    }


    #endregion
}
