using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using UnityEngine.UI;
using EnumCollection;

namespace Beans2022.Buttons
{
    public class ButtonManager : MonoBehaviour
    {
        #region Fields
    
        #endregion

        #region Public Functions

        public void StartGame()
        {
            GameManager.Instance.SwitchState(GameState.GameStarting);
        }

        public void QuitGame()
        {
            GameManager.Instance.SwitchState(GameState.Quit);
        }

        public void OpenSettings()
        {
            GameManager.Instance.SwitchState(GameState.Settings);
        }

        public void OpenCredits()
        {
            GameManager.Instance.SwitchState(GameState.Credits);
        }
        #endregion

    }
}
