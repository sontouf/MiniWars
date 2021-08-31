using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : UnitInfo
{
    protected override void Start()
    {
        maxHp = 230;
        base.Start();
        curHp = maxHp;
        damage = 10;
        speed *= 3;
        atkCooltime = 0.5f;

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
