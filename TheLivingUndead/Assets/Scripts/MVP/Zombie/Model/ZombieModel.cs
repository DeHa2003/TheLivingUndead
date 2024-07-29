using ModestTree.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieModel
{
    public ZombieMoveModel MoveModel { get; private set; }
    public ZombieActionModel ActionModel { get; private set; }
    public ZombieHealthModel HealthModel { get; private set; }

    public ZombieModel(ZombieMoveModel moveModel, ZombieActionModel actionModel, ZombieHealthModel healthModel)
    {
        MoveModel = moveModel;
        ActionModel = actionModel;
        HealthModel = healthModel;
    }
}
