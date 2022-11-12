using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _floor;
    private Vector3 _floorPosition = new Vector3();
    private Vector3 _newFloorPosition;

    [SerializeField] private float xBoundary;

    [SerializeField] private float xSpawnPosition;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _newFloorPosition = new Vector3(xSpawnPosition, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        _floorPosition = gameObject.transform.position;

        if (_floorPosition.x <= xBoundary)
        {
            Instantiate(_floor, _newFloorPosition, Quaternion.identity);
            Destroy(gameObject);
        }

        
    }
}
