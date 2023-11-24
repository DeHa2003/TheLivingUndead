using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : VisualEffectButton
{
    public void Continue()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
