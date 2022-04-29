using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().child)
        {
            Destroy(animator.GetComponent<UnitInfo>().child.gameObject); // 체력바
        }
        if (animator.GetComponent<UnitInfo>().positionObject)
        {
            Destroy(animator.GetComponent<UnitInfo>().positionObject); // position 유닛.
        }
        animator.GetComponent<BoxCollider2D>().enabled = false;
        animator.GetComponent<SpriteRenderer>().sortingOrder = 0;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, 3f);
    }

}
