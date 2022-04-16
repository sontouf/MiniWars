using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredSward : UnitInfo
{
    protected override void Start()
    {
        maxHp = 270;
        curHp = maxHp;
        damage = 10;
        speed *= 0.6f;
        base.Start();
    }

}
