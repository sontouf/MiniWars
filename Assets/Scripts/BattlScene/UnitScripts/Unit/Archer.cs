using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : UnitInfo
{
    protected override void Start()
    {
        maxHp = 100;
        base.Start();
        curHp = maxHp;
        damage = 12;
        speed *= 1f;

    }

}
