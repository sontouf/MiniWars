using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
        if (!animator.GetComponent<Shield>())
        {
            float speed = animator.GetComponent<UnitInfo>().speed * -4 * Time.deltaTime;
            animator.transform.Translate(speed, 0, 0);
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<UnitInfo>().isHit = false;
    }
}
