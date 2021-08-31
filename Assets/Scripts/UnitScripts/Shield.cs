using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : UnitInfo
{
    protected override void Start()
    {
        maxHp = 300;
        base.Start();
        curHp = maxHp;
        damage = 15;
        speed *= 1;

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
