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
            GameObject temp;
            switch (randomBackground)
            {               
                case 1:
                    temp = Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
                    temp.transform.eulerAngles= new Vector3(10,0,0);
                    Debug.Log(temp.transform.position);
                    break;

                case 2:
                    temp = Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
                    temp.transform.eulerAngles = new Vector3(10, 0, 0);
                    Debug.Log(temp.transform.position);
                    break;

                case 3:
                    temp = Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
                    temp.transform.eulerAngles = new Vector3(10, 0, 0);
                    Debug.Log(temp.transform.position);
                    break;

                case 4:
                    temp = Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
                    temp.transform.eulerAngles = new Vector3(10, 0, 0);
                    Debug.Log(temp.transform.position);
                    break;

                case 5:
                    temp = Instantiate(_background1, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
                    temp.transform.eulerAngles = new Vector3(10, 0, 0);
                    Debug.Log(temp.transform.position);
                    break;

            }
            

            hasInstantiated = true;
        } 
    }
}
