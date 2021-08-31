using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    ScanEnemy scanEnemy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scanEnemy = animator.GetComponent<ScanEnemy>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!scanEnemy.scanEnemy)
        {
            animator.SetTrigger("Ready"); // 때리다가 죽으면.
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject != null && scanEnemy.scanEnemy)
        {
            if (scanEnemy.scanEnemy.GetComponent<UnitInfo>()) // 유닛이면
            {
                scanEnemy.scanEnemy.GetComponent<UnitInfo>().curHp -= animator.GetComponent<UnitInfo>().damage;
            }
            else if (scanEnemy.scanEnemy.GetComponent<BlueCost>())// 성이면
            {
               BlueCastleBar.curHp -= animator.GetComponent<UnitInfo>().damage;
            }
            else if (scanEnemy.scanEnemy.GetComponent<RedCost>())
            {
               RedCastleBar.curHp -= animator.GetComponent<UnitInfo>().damage;
            }
           
/*            if (!animator.gameObject.GetComponent<Archer>())
            {
                animator.gameObject.GetComponent<ScanEnemy>().scanEnemy.GetComponent<UnitInfo>().curHp -= animator.gameObject.GetComponent<UnitInfo>().damage;
            }
            else
            {
                Instantiate()
            }*/
        }


        animator.GetComponent<UnitInfo>().atkDelay = animator.GetComponent<UnitInfo>().atkCooltime;
    }
}
