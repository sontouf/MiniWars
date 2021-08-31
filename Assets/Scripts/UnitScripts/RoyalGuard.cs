using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalGuard : UnitInfo
{
    protected override void Start()
    {
        maxHp = 600;
        base.Start();
        curHp = maxHp;
        damage = 50;
        speed *= 0.7f;

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
