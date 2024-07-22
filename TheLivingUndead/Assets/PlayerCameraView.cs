using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraView : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private IEnumerator zoomEnumertaor;

    public void SetZoom(float FOV, float duration)
    {
        if (zoomEnumertaor != null)
            Coroutines.StopCoroutine_(zoomEnumertaor);

        Coroutines.StartCoroutine_(zoomEnumertaor = ChangeZoom(FOV, duration));
    }

    private IEnumerator ChangeZoom(float fov, float duration)
    {
        float startFOV = virtualCamera.m_Lens.FieldOfView;
        float elapsed = 0;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOV, fov, elapsed/duration);
            yield return null;
        }

        virtualCamera.m_Lens.FieldOfView = fov;
    }
}
