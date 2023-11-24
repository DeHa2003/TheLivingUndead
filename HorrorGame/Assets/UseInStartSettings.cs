using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInStartSettings : MonoBehaviour
{
    public GameplaySettingsScript gameplaySettingsScript;
    public EffectsSettingsScript effectsSettingsScript;
    // Start is called before the first frame update
    private void Start()
    {
        gameplaySettingsScript.InitializeSettings();
        effectsSettingsScript.InitializeSettings();
    }
}
