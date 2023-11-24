using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public SpawnerZombie spawnerZombie;
    public int killCountZombies = 0;
    public int countToSuccessGame;

    public GameObject player;
    public UnityEngine.Events.UnityEvent unityEventInTheEnd;
    private bool finishGame = false;
    private void Start()
    {
        if(spawnerZombie != null)
        countToSuccessGame = spawnerZombie.maxCount;
    }
    private void Update()
    {
        if(killCountZombies >= countToSuccessGame)
        {
            if(finishGame == false)
            {
                finishGame = true;
                unityEventInTheEnd.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
