using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSignalsListener : MonoBehaviour
{

    public event Action OnFootstepEvent;
    public event Action OnAttackEvent;
    public event Action OnRiseUpEvent;

    public void SignalAttack()
    {
        OnAttackEvent?.Invoke();
    }

    public void SignalFootstep()
    {
        OnFootstepEvent?.Invoke();
    }

    public void SignalRiseUp()
    {
        OnRiseUpEvent?.Invoke();
    }
}
