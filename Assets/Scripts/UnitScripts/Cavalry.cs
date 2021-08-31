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

    // Update is called once per frame
    protected override void Update()
    {
        if (curHp <= 0 && !isDead)
        {
            GetComponent<Animator>().SetTrigger("Die");
            isDead = !isDead;
        }
        base.Update();
    }
}
