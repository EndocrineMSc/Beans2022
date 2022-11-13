using Beans2022;
using EnumCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{ 

   [SerializeField] private GameObject mainMenu;
    
   // Update is called once per frame
   void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            if(GameManager.Instance.State == EnumCollection.GameState.GameStarting)
            {
                GameManager.Instance.SwitchState(EnumCollection.GameState.Pause);
            }
            else if(GameManager.Instance.State == EnumCollection.GameState.Pause)
            {
                GameManager.Instance.SwitchState(EnumCollection.GameState.GameStarting);
            }
            else
            {
                GameManager.Instance.SwitchState(EnumCollection.GameState.MainMenu);
            }
     
        }
    }
}
