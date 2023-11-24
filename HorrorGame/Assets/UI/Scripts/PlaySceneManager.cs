using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlaySceneManager : MonoBehaviour
{
    public VideoClip[] clips;
    public static int clipNumber = 0;
    public static int numberPlayScene = 4;

    private ulong allFrameCount;
    private VideoPlayer videoPlayer;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[clipNumber - 1];
        allFrameCount = videoPlayer.frameCount;
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.frame >= (long)allFrameCount-1 || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(numberPlayScene);
        }
    }
}
