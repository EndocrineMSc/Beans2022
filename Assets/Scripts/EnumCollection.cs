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
        Kaffee,
        Energy,
        ColaFlasche,
        ColaDose,
        Kissen,
        Bier,
    }

    public enum PickUpEffect
    {
        Booster,
        Downer,
    }

    public enum SFX
    {
        AlternativeJump = 0,
        Jump = 1,
        Moan1 = 2,
        Moan2 = 3,
        ButtonClick = 4,
        BottleOpening = 5,
        CanOpening = 6,
        Drinking = 7,
        Munch = 8,
        Burp = 9,
    }
}