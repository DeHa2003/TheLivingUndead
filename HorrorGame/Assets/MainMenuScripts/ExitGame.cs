using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : VisualEffectButton
{
    public void CloseGame()
    {
        Application.Quit();
    }
}
