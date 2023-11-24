using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(0);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        if (!asyncOperation.isDone)
        {

        }
    }
}
