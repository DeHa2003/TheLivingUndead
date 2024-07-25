using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthView : MonoBehaviour
{
    [SerializeField] private BodyPartConfig[] bodyPartConfigs;

    private void Start()
    {
        foreach(BodyPartConfig config in bodyPartConfigs)
        {
            config.Initialize();
        }
    }
}
