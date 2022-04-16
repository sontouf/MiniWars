using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : UnitInfo
{
    protected override void Start()
    {
        maxHp = 450;
        base.Start();
        curHp = maxHp;
        damage = 13;
        speed *= 0.8f;

    }

    // Update is called once per framea
}
