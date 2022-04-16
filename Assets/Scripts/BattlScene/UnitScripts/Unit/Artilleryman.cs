using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artilleryman : UnitInfo
{
    protected override void Start()
    {
        maxHp = 200;
        base.Start();
        curHp = maxHp;
        damage = 25;
        speed *= 0.5f;

    }

}
