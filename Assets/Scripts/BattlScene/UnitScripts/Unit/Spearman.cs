using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : UnitInfo
{
    protected override void Start()
    {
        maxHp = 300;
        base.Start();
        curHp = maxHp;
        damage = 20;
        speed *= 1.1f;
        atkCooltime = 1f;

    }

}
