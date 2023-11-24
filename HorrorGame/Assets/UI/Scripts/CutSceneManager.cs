using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    private VideoPlayer player;
    private ulong allFramesInVideo;
    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        allFramesInVideo = player.frameCount - 1;
    }

    private void Update()
    {
        if(player.frame >= (long)allFramesInVideo) 
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
