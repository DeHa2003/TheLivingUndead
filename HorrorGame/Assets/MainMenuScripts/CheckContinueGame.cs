using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContinueGame : MonoBehaviour
{
    public GameObject continueGame;
    private void Start()
    {
        if(PlaySceneManager.clipNumber != 0)
        {
            continueGame.SetActive(true);
        }
    }
}
