using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;

public class ObjectMovement : MonoBehaviour
{
    #region Fields

    private Rigidbody _rigidbody;
    private float _speed;

    #endregion

    #region Private Functions

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = GameManager.Instance.Speed;

        _rigidbody.velocity = new Vector3(_speed, 0, 0);
    }

    #endregion
}
