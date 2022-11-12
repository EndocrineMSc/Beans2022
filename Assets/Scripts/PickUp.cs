using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using EnumCollection;

namespace Beans2022.PickUps
{

    public class PickUp : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _timeBonus;
        [SerializeField] private PickUpType _type;
        private Rigidbody _rigidbody;
        private float _yRotation;
        private float _smooth = 5;

        #endregion

        #region Private Functions
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("Player"))
            {
                PickUpEffect();
                Destroy(gameObject);
            }
        }


        private void PickUpEffect()
        {
            switch (_type)
            {
                case PickUpType.Booster:
                    GameManager.Instance.SleepTimer += _timeBonus;
                    break;

                case PickUpType.Downer:
                    GameManager.Instance.SleepTimer -= _timeBonus;
                    break;
            }
        }

        private void Update()
        {
            _yRotation += 1;

            if (_yRotation >= 360)
            { _yRotation = 0; }

            Quaternion target = Quaternion.Euler(15, _yRotation, 15);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }

        #endregion

    }
}
