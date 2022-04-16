using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MoveState : StateMachineBehaviour
{
    Transform swardTransform;
    Sward sward;
    ScanEnemy scanEnemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
        scanEnemy = animator.GetComponent<ScanEnemy>();
        swardTransform = animator.GetComponent<Transform>();
        if (scanEnemy.scanEnemy) // 적이 있으면.
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
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
        scanEnemy.scanEnemy = scanEnemy.FindUnit();
        if (scanEnemy.scanEnemy) // 적이 있으면.
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
            float speed = animator.GetComponent<UnitInfo>().speed * Time.deltaTime;
            swardTransform.Translate(speed, 0, 0);

        }

    }


}
