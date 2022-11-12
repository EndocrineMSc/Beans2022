using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beans2022.Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region Fields
        private AudioSource audioSourceSFX;
        private AudioSource audioSourceMusic;
        [SerializeField] private AudioSource bgMusicOne;
        [SerializeField] private AudioSource bgMusicTwo;
        [SerializeField] private AudioSource bgMusicThree;
        [SerializeField] private GameObject voiceLineObject;
        private AudioSource[] randomVoiceLines;

        [SerializeField] private float _fadeSpeed = 0.1f;
        [SerializeField] private float _volumeIncrement = 0.1f;

        private float sleepPercent; //how tired are we in percentage of the SpeedTimer
        private float maxTimer; //how much time does the player start with (get from Game Manager)
        private bool waiting; //for random Voice Line IEnumerator

        #endregion

        #region Properties

        private float _musicVolume;

        public float Volume
        {
            get { return _musicVolume; }
            set { _musicVolume = value; }
        }

        private float _sfxVolume;

        public float SFXVolume
        {
            get { return _sfxVolume; }
            set { _sfxVolume = value; }
        }

        #endregion

        #region Public Functions

        public void PlayAudioClip(AudioClip audioClip)
        {
            audioSourceSFX.volume = _sfxVolume;
            audioSourceSFX.clip = audioClip;
            audioSourceSFX.Play();
        }

        #endregion


        #region Private Functions

        private void Start()
        {
            bgMusicOne.volume = 0;
            bgMusicTwo.volume = 0;
            bgMusicThree.volume = 0;

            maxTimer = GameManager.Instance.SleepTimer;
            randomVoiceLines = voiceLineObject.GetComponents<AudioSource>();
        }

        private void Update()
        {
            sleepPercent = (GameManager.Instance.SleepTimer / maxTimer); //gives percentage loss of time

            if (sleepPercent > 0.7)
            {
                if (bgMusicOne.volume < _musicVolume)
                {
                    StartCoroutine(FadeInTrack(bgMusicOne));
                }

                if (bgMusicTwo.volume >= _musicVolume)
                {
                    StartCoroutine(FadeOutTrack(bgMusicTwo));
                }
            }
            else if (sleepPercent < 0.7 && sleepPercent > 0.3)
            {
                if (bgMusicThree.volume >= _musicVolume)
                {
                    StartCoroutine(FadeOutTrack(bgMusicThree));
                }

                if (bgMusicTwo.volume < _musicVolume)
                {
                    StartCoroutine(FadeInTrack(bgMusicTwo));
                }  
            }
            else if (sleepPercent < 0.3)
            {
                if (bgMusicTwo.volume >= _musicVolume)
                {
                    StartCoroutine(FadeOutTrack(bgMusicTwo));
                }

                if (bgMusicThree.volume < _musicVolume)
                {
                    StartCoroutine(FadeInTrack(bgMusicThree));
                }
            }

            if (!waiting)
            {
                StartCoroutine(nameof(RandomVoiceLineGenerator));
            }
        }

        #endregion

        #region IEnumerators

        private IEnumerator FadeInTrack(AudioSource audioSource)
        {
            audioSource.volume = 0;

            while (audioSourceMusic.volume < _musicVolume)
            {
                yield return new WaitForSeconds(_fadeSpeed);
                audioSource.volume += _volumeIncrement;  
            }
        }

        private IEnumerator FadeOutTrack(AudioSource audioSource)
        {
            audioSource.volume = _musicVolume;

            while (audioSource.volume >= _musicVolume)
            {
                yield return new WaitForSeconds(_fadeSpeed);
                audioSource.volume -= _volumeIncrement;
            }
        }

        private IEnumerator RandomVoiceLineGenerator()
        {
            waiting = true;
            float voiceLineWaitTime = Random.Range(5,20);
            int voiceLineIndex = Random.Range(0, randomVoiceLines.Length);

            AudioSource voiceLine = randomVoiceLines[voiceLineIndex];
            voiceLine.Play();
            yield return new WaitForSeconds(voiceLineWaitTime);
            waiting = false;
        }

        #endregion

    }
}

