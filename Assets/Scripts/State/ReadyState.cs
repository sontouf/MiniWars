using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    ScanEnemy scanEnemy;
    bool scanEnemyDead;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scanEnemy = animator.GetComponent<ScanEnemy>();
       
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scanEnemy.scanEnemy = scanEnemy.FindUnit();
        if (scanEnemy.scanEnemy) // 적이 있으면.
        {
            if (animator.GetComponent<UnitInfo>().atkDelay <= 0)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            scanEnemy.scanEnemy = scanEnemy.FindUnit();
            if (scanEnemy.scanEnemy)
            {
                if (animator.GetComponent<UnitInfo>().atkDelay <= 0)
                {
                    animator.SetTrigger("Attack");
                }
                else
                {
                    animator.SetTrigger("Ready");
                }
            }
            else
            {
                animator.SetTrigger("Move");
            }
        }



    }



}
