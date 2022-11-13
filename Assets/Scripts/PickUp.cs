using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using EnumCollection;
using Unity.VisualScripting;

namespace Beans2022.PickUps
{

    public class PickUp : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _timeBonus;
        [SerializeField] private PickUpType _type;
        private float hoverSpeed = 15f;
        private Rigidbody _rigidbody;
        private float _yPositionStart;
        private float upperBorder;
        private float lowerBorder;
        private bool goUp;

        #endregion

        #region Private Functions
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _yPositionStart = _rigidbody.transform.position.y;
            upperBorder = _yPositionStart + 0.5f;
            lowerBorder = _yPositionStart - 0.5f;
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

            if(goUp)
            {
                if (_rigidbody.transform.position.y > upperBorder)
                {
                    _rigidbody.velocity = new Vector3(0, 0, 0);
                    goUp = false;
                }
                else
                {
                    _rigidbody.AddForce(new Vector3(0, hoverSpeed, 0));
                }
            }

            if(!goUp)
            {
                Debug.Log("UpperBorder = " + upperBorder);
                Debug.Log("LowerBorder = " + lowerBorder);
                Debug.Log(goUp);

                if (_rigidbody.transform.position.y < lowerBorder)
                {
                    _rigidbody.velocity = new Vector3(0,0,0);
                    goUp = true;
                }
                else
                {
                    _rigidbody.AddForce(new Vector3(0,-hoverSpeed,0));
                }

                Debug.Log("Velocity: " + _rigidbody.velocity);

               
            }

            
        }

        #endregion

    }
}
