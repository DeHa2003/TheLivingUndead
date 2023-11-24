using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessGameScript : VisualEffectButton
{
    public void OpenSceneMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PlaySceneManager.clipNumber++;
        PlaySceneManager.numberPlayScene++;
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
