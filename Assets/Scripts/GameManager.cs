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
		[SerializeField] private Canvas _highscoresStart;
		[SerializeField] private Canvas _highscoresEnd;
		[SerializeField] private Canvas _gameOver;
		

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

		#endregion

		#region Public Functions

		public void SwitchState(GameState state)
		{
			_state = state;

			switch (_state)
			{
				case GameState.MainMenu:
					Instance._mainMenu.gameObject.SetActive(true);
					Instance._pauseMenu.gameObject.SetActive(false);
					Instance._credits.gameObject.SetActive(false);
					Instance._highscoresEnd.gameObject.SetActive(false);
					Instance._highscoresStart.gameObject.SetActive(false);
					Instance._gameOver.gameObject.SetActive(false);
					Instance._settings.gameObject.SetActive(false);
					break;

				case GameState.Credits:
					Instance._mainMenu.gameObject.SetActive(false);
					Instance._credits.gameObject.SetActive(true);
					break;

				case GameState.Settings:
					Instance._settings.gameObject.SetActive(true);
					break;

				case GameState.GameStarting:
					Time.timeScale = 1;
                    GetComponent<CameraManager>().gameObject.SetActive(true);
                    break;

				case GameState.GameLoop:
					break;

				case GameState.GameOver:
                    Time.timeScale = 0;
                    Instance._gameOver.gameObject.SetActive(true);
					
					break;

				case GameState.HighScoreMenu:
					break;

				case GameState.HighScoreEnd:
					break;

				case GameState.Pause:
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
			DontDestroyOnLoad(gameObject);
		}

		#endregion


	}
}
