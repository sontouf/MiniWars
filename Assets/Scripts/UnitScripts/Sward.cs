using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sward : UnitInfo
{
    // Start is called before the first frame update
    protected override void Start()
    {
        maxHp = 130;
        base.Start();
        curHp = maxHp;
        damage = 7;
        speed *= 1.5f;

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
