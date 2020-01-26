using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_MainMenu : UI_MenuBase
{
    public void GoToGameplay()
    {
        GameManager.I.GoToNext();
    }
}
