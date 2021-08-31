using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        if (animator.gameObject.layer == 8)
        {
            GameManager.blueCurUnitNumber -= 1;
        }
        else if (animator.gameObject.layer == 9)
        {
            GameManager.redCurUnitNumber -= 1;
        }

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, 3f);
    }

}
