using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumCollection
{
    public enum GameState
    {
        MainMenu,
        Credits,
        Settings,
        Quit,
        GameOver,
        HighScoreMenu,
        HighScoreEnd,
        GameStarting,
        GameLoop,
        Pause,
    }

    public enum Booster
    {
        Kaffee,
        Energy,
        Cola,
        Riegel,
    }

    public enum Downer
    {
        Kissen,
        Bier,
    }

    public enum PickUpType
    {
        Booster,
        Downer,
    }
}