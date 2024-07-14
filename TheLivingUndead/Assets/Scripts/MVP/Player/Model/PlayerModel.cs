using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public PlayerMoveModel MoveModel { get; private set; }
    public PlayerWeaponModel WeaponModel { get; private set; }

    public PlayerModel(PlayerMoveModel playerMoveModel, PlayerWeaponModel playerWeaponModel)
    {
        this.MoveModel = playerMoveModel;
        this.WeaponModel = playerWeaponModel;
    }
}
