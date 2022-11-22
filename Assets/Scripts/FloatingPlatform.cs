using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    #region Fields

    private float _despawnBorderX = -30f;
    private float _currentPositionX;

    #endregion

    #region Private Functions

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //do nothing
        }
        else
        {
            collision.gameObject.transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _currentPositionX = transform.position.x;

        if (_currentPositionX <= _despawnBorderX) 
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
