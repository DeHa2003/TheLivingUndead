using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FailGameScript : VisualEffectButton
{
    public void OpenSceneMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
