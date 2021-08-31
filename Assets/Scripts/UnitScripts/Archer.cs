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
