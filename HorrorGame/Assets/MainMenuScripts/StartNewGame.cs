using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : VisualEffectButton
{
    public void StartNewPlotOfTheStory()
    {
        PlaySceneManager.clipNumber = 1;
        PlaySceneManager.numberPlayScene = 4;
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
