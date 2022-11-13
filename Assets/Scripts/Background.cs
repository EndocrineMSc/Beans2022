using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _background1;
    [SerializeField] private GameObject _background2;
    [SerializeField] private GameObject _background3;
    [SerializeField] private GameObject _background4;
    [SerializeField] private GameObject _background5;

    private Vector3 _backgroundPosition = new Vector3();

    [SerializeField] private float xBoundary;
    private float xSpawnPosition = 99.9f;
    private float xSpawnBoundary = -15;
    [SerializeField] private float ySpawnPosition;
    [SerializeField] private float zSpawnPosition;
    private int randomBackground;

    private bool hasInstantiated;

    #endregion

    private void Start()
    {
        randomBackground = Random.Range(1, 6);
    }

    void Update()
    {
        _backgroundPosition = gameObject.transform.position;

        if (_backgroundPosition.x <= xSpawnBoundary && !hasInstantiated)
        {
            randomBackground = Random.Range(1, 6);
            Debug.Log("Random Background: " + randomBackground);
            switch (randomBackground)
            {               
                case 1:
                    Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.Euler(10, 0, 0));

                    break;

                case 2:
                    Instantiate(_background2, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.Euler(10, 0, 0));

                    break;

                case 3:
                    Instantiate(_background3, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.Euler(10, 0, 0));

                    break;

                case 4:
                    Instantiate(_background4, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.Euler(10, 0, 0));
                    
                    break;

                case 5:
                    Instantiate(_background5, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.Euler(10, 0, 0));
                    
                    break;

            }
            
            hasInstantiated = true;
        } 
    }
}
