using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _floor1;
    [SerializeField] private GameObject _floor2;
    [SerializeField] private GameObject _floor3;

    private Vector3 _floorPosition = new Vector3();
    private Vector3 _newFloorPosition;

    [SerializeField] private float xBoundary;
    [SerializeField] private float xSpawnPosition;
    [SerializeField] private float xSpawnBoundary;
    private float ySpawnPosition;
    private int randomFloor;

    private bool hasInstantiated;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        randomFloor = Random.Range(1, 4);
        string plattformName = gameObject.name;

        if (plattformName.Contains("Plattform1"))
        {
            ySpawnPosition = -14.8f;
        }

        if (plattformName.Contains("Plattform2") || plattformName.Contains("Plattform3"))
        {
            ySpawnPosition = -15.3f;
        }

        _newFloorPosition = new Vector3(xSpawnPosition, ySpawnPosition, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        _floorPosition = gameObject.transform.position;

        if (_floorPosition.x <= xSpawnBoundary && !hasInstantiated)
        {
            switch (randomFloor)
            {
                case 1:
                    Instantiate(_floor1, new Vector3(xSpawnPosition, -14.8f, 0), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(_floor2, new Vector3(xSpawnPosition, -15.3f, 0), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(_floor3, new Vector3(xSpawnPosition, -15.3f, 0), Quaternion.identity);
                    break;
            }

            hasInstantiated= true;
        }


        if (_floorPosition.x <= xBoundary)
        {

            Destroy(gameObject);
        }

    }
}
