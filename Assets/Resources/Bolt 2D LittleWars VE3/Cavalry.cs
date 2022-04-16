using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : UnitInfo
{
    protected override void Start()
    {
        maxHp = 400;
        base.Start();
        curHp = maxHp;
        damage = 20;
        speed *= 2;
        atkCooltime = 0.7f;

    }


}
