using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookToObj : MonoBehaviour
{
    public Transform lookingObj;

    private void Update()
    {
        gameObject.transform.LookAt(lookingObj);
    }
}
