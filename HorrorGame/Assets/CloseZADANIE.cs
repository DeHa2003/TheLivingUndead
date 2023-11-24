using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseZADANIE : MonoBehaviour
{
    public GameObject menuPanel;
    public void CloseZadanie()
    {
        gameObject.SetActive(false);
        menuPanel.SetActive(true);
    }
}
