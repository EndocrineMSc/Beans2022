using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using EnumCollection;
using Unity.VisualScripting;
using Beans2022.Audio;

namespace Beans2022.PickUps
{

    public class PickUp : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _timeBonus;
        [SerializeField] private PickUpType _type;
        [SerializeField] private PickUpEffect _effect;
        private AudioManager audioManager;
        private float hoverSpeed = 15f;
        private Rigidbody _rigidbody;
        private float _yPositionStart;
        private float upperBorder;
        private float lowerBorder;
        private bool goUp;

        #endregion

        #region Properties

        public PickUpType Type
        { get { return _type; } }

        #endregion

        #region Private Functions

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _yPositionStart = _rigidbody.transform.position.y;
            upperBorder = _yPositionStart + 0.5f;
            lowerBorder = _yPositionStart - 0.5f;
            audioManager = GameManager.Instance.GetComponent<AudioManager>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("Player"))
            {
                CountEffect();
                StartCoroutine(nameof(PlayPickUpSFX));
                Destroy(gameObject);
            }
        }


        private void CountEffect()
        {
            switch (_effect)
            {
                case PickUpEffect.Booster:
                    GameManager.Instance.SleepTimer += _timeBonus;
                    break;

                case PickUpEffect.Downer:
                    GameManager.Instance.SleepTimer -= _timeBonus;
                    break;
            }
        }

        private IEnumerator PlayPickUpSFX()
        {
            switch (_type)
            {
                case PickUpType.Bier:
                    audioManager.PlaySoundEffect(SFX.Drinking);
                    yield return new WaitForSeconds(1f);
                    audioManager.PlaySoundEffect(SFX.Burp);
                    break;

                case PickUpType.Kissen:
                    audioManager.PlaySoundEffect(SFX.Moan2);
                    break;

                case PickUpType.Kaffee:
                    audioManager.PlaySoundEffect(SFX.Drinking);
                    break;

                case PickUpType.ColaDose:
                    audioManager.PlaySoundEffect(SFX.CanOpening);
                    yield return new WaitForSeconds(1f);
                    audioManager.PlaySoundEffect(SFX.Drinking);
                    break;

                case PickUpType.ColaFlasche:
                    audioManager.PlaySoundEffect(SFX.BottleOpening);
                    yield return new WaitForSeconds(1f);
                    audioManager.PlaySoundEffect(SFX.Drinking);
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

                if (_rigidbody.transform.position.y < lowerBorder)
                {
                    _rigidbody.velocity = new Vector3(0,0,0);
                    goUp = true;
                }
                else
                {
                    _rigidbody.AddForce(new Vector3(0,-hoverSpeed,0));
                }
 
            }

            if (transform.position.x < -50f)
            {
                Destroy(gameObject);
            }

            
        }

        #endregion

    }
}
