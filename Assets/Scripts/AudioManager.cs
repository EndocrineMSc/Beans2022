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

        [SerializeField] private float _fadeSpeed = 0.5f;
        [SerializeField] private float _volumeIncrement = 0.05f;

        private float sleepPercent; //how tired are we in percentage of the SpeedTimer
        private float maxTimer; //how much time does the player start with (get from Game Manager)
        private bool waiting; //for random Voice Line IEnumerator


        private bool waitForFadeOut;
        private bool waitForFadeIn;

        #endregion

        #region Properties

        private float _musicVolume = 1;

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

        public void PlayMusic()
        {
            bgMusicOne.Play();
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
            bgMusicOne.Play();
        }

        private void Update()
        {
            sleepPercent = (GameManager.Instance.SleepTimer / maxTimer); //gives percentage loss of time

            Debug.Log(sleepPercent);
            if (sleepPercent > 0.7f)
            {
                if (bgMusicOne.volume < _musicVolume && !waitForFadeIn)
                {
                    StartCoroutine(FadeInTrack(bgMusicOne, _musicVolume));
                }

                if (bgMusicTwo.volume >= _musicVolume)
                {
                    StartCoroutine(FadeOutTrack(bgMusicTwo, 0));
                }
            }
            else if (sleepPercent < 0.7f && sleepPercent > 0.3f && !waitForFadeOut)
            {
                if (bgMusicOne.volume > _musicVolume *0.7f)
                {
                    float fadeVolume = _musicVolume * 0.7f;
                    Debug.Log("FadeVolume Track 1: " + fadeVolume);
                    StartCoroutine(FadeOutTrack(bgMusicOne, fadeVolume));
                    Debug.Log("Track 1 after fade: " + bgMusicOne.volume);
                }

                
                if (bgMusicOne.volume < _musicVolume * 0.7f && !waitForFadeIn)
                {
                    float fadeVolume = _musicVolume * 0.7f;
                    StartCoroutine(FadeInTrack(bgMusicOne, fadeVolume));
                }

                if (bgMusicThree.volume >= _musicVolume && !waitForFadeOut)
                {
                    StartCoroutine(FadeOutTrack(bgMusicThree, 0));
                }

                if (bgMusicTwo.volume < _musicVolume && !waitForFadeIn)
                {
                    StartCoroutine(FadeInTrack(bgMusicTwo, _musicVolume));
                }  
            }
            else if (sleepPercent < 0.3)
            {
                if (bgMusicOne.volume >= _musicVolume * 0.5 && !waitForFadeOut)
                {
                    float fadeVolume = _musicVolume * 0.5f;
                    StartCoroutine(FadeOutTrack(bgMusicOne, fadeVolume));
                }

                if (bgMusicThree.volume < _musicVolume && !waitForFadeIn)
                {
                    StartCoroutine(FadeInTrack(bgMusicThree, _musicVolume));
                }
            }

            if (!waiting)
            {
                StartCoroutine(nameof(RandomVoiceLineGenerator));
            }
        }

        #endregion

        #region IEnumerators

        private IEnumerator FadeInTrack(AudioSource audioSource, float fadeVolume)
        {
            waitForFadeIn = true;
            while (audioSource.volume < fadeVolume)
            {
                yield return new WaitForSeconds(_fadeSpeed);
                audioSource.volume += _volumeIncrement;  
            }
            waitForFadeIn = false;
        }

        private IEnumerator FadeOutTrack(AudioSource audioSource, float fadeVolume)
        {
            waitForFadeOut = true;
            int i = 1;
            while (audioSource.volume >= fadeVolume)
            {
                yield return new WaitForSeconds(_fadeSpeed);
                audioSource.volume -= _volumeIncrement;
                Debug.Log("Durchlauf i: " + i + "Volume: " + audioSource.volume);
                i++;
            }
            waitForFadeOut= false;
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

