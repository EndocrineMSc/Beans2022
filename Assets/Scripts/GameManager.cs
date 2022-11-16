using EnumCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Beans2022.Audio;

namespace Beans2022
{
	public class GameManager : MonoBehaviour
	{
		#region Fields

		public static GameManager Instance;
		[SerializeField] private Canvas _mainMenu;
		[SerializeField] private Canvas _credits;
		[SerializeField] private Canvas _settings;
		[SerializeField] private Canvas _pauseMenu;
		[SerializeField] private Canvas _gameOver;
		
		private float startGamespeed;
		private float startSleepTimer;
		private float startBlinkTimer;

		#endregion

		#region Properties

		private GameState _state;

		public GameState State
		{
			get { return _state; }
			private set { _state = value; }
		}

		[SerializeField] private float _gameSpeed;

		public float Speed
		{
			get { return _gameSpeed; }
			private set { _gameSpeed = value; }
		}

        [SerializeField]
        private float _sleepTimer = 20f;

		public float SleepTimer
		{
			get { return _sleepTimer; }
			set { _sleepTimer = value; }
		}

		private float _blinkTimer = 10f;

		public float BlinkTimer
		{
			get { return _blinkTimer; }
			set { _blinkTimer = value; }
		}

		#endregion

		#region Public Functions

		public void SwitchState(GameState state)
		{
			_state = state;

			switch (_state)
			{
				case GameState.MainMenu:
                    BlinkTimer = startBlinkTimer;
                    SleepTimer = startSleepTimer;
                    _gameSpeed = startGamespeed;
                    Instance._mainMenu.gameObject.SetActive(true);
					Instance._pauseMenu.gameObject.SetActive(false);
					Instance._credits.gameObject.SetActive(false);
					Instance._gameOver.gameObject.SetActive(false);
					Instance._settings.gameObject.SetActive(false);
                    break;

				case GameState.Credits:
                    Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(false);
                    Instance._credits.gameObject.SetActive(true);
                    Instance._gameOver.gameObject.SetActive(false);
                    Instance._settings.gameObject.SetActive(false);
                    Time.timeScale = 0;                 
                    break;

				case GameState.Settings:
                    Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(false);
                    Instance._credits.gameObject.SetActive(false);
                    Instance._gameOver.gameObject.SetActive(false);
                    Instance._settings.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    break;

				case GameState.GameStarting:
                    GetComponent<CameraManager>().gameObject.SetActive(true);
					Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(false);
                    Instance._credits.gameObject.SetActive(false);
                    Instance._gameOver.gameObject.SetActive(false);
                    Instance._settings.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    break;

				case GameState.GameOver:
					
                    Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(false);
                    Instance._credits.gameObject.SetActive(false);
                    Instance._gameOver.gameObject.SetActive(true);
                    Instance._settings.gameObject.SetActive(false);
                    Time.timeScale = 0;
                    break;
				case GameState.HighScoreEnd:
                    Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(false);
                    Instance._credits.gameObject.SetActive(false);
                    Instance._gameOver.gameObject.SetActive(false);
                    Instance._settings.gameObject.SetActive(false);
                    Time.timeScale = 0;
                    break;

				case GameState.Pause:
                    Instance._mainMenu.gameObject.SetActive(false);
                    Instance._pauseMenu.gameObject.SetActive(true);
                    Instance._credits.gameObject.SetActive(false);
                    Instance._gameOver.gameObject.SetActive(false);
                    Instance._settings.gameObject.SetActive(false);
                    Time.timeScale = 0;
                    break;

				case GameState.Quit:

#if UNITY_EDITOR
					EditorApplication.ExitPlaymode();
#endif
					Application.Quit();
					break;

			}
		}

		public IEnumerator SlowDown()
		{
			float originalSpeed = Speed;
			float step = (Speed + 3f) / 200;
			Speed = -3f;
			while (Speed > originalSpeed)
			{
				Speed += step;
				yield return new WaitForSeconds(0.01f);
			}
		}

		#endregion

		#region Private Functions
		private void Awake()
		{
			Instance = this;
            Time.timeScale = 0;
			DontDestroyOnLoad(gameObject);
		}
		private void Start()
		{
			startBlinkTimer = BlinkTimer;
			startGamespeed = _gameSpeed;
			startSleepTimer = SleepTimer;
			Instance.SwitchState(GameState.MainMenu);
		}

		#endregion


	}
}
