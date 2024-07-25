using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyPartConfig
{
    [SerializeField] private BodyPart bodyPart;
    [SerializeField] private Transform[] bodyPartTransforms;

    public void Initialize()
    {
        foreach (Transform t in bodyPartTransforms)
        {
            var partCollider = t.gameObject.AddComponent<BodyPartCollider>();
            partCollider.Initialize(bodyPart);
        }
    }
}

public enum BodyPart
{
    LeftHand, RightHand, LeftFoot, RightFoot, Head
}
