using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    
    ScanEnemy scanEnemy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
        scanEnemy = animator.GetComponent<ScanEnemy>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<UnitInfo>().isDead)
        {
            animator.SetTrigger("Die");
        }
        if (!scanEnemy.scanEnemy)
        {
            animator.SetTrigger("Ready"); // 때리다가 죽으면.
        }
        //animator.SetTrigger("Ready");

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UnitInfo unitInfo = animator.GetComponent<UnitInfo>();
        if (animator.gameObject != null && scanEnemy.scanEnemy && !unitInfo.isHit)
        {

            if ( animator.GetComponent<RoyalGuard>() || animator.GetComponent<Spearman>() || animator.GetComponent<Artilleryman>())
            {
                if (animator.gameObject.layer == 8)
                {
                    Knockback("Red", animator);
                }
                else
                {
                    Knockback("Blue", animator);
                }
            }
            else
            {
                UnitInfo scanEnemyInfo = scanEnemy.scanEnemy.GetComponent<UnitInfo>();
                if (scanEnemyInfo) // 유닛이면
                {
                    
                    scanEnemyInfo.curHp -= animator.GetComponent<UnitInfo>().damage;
                    scanEnemy.scanEnemy.GetComponent<HpBarController>().SetHealth(scanEnemyInfo.curHp, scanEnemyInfo.maxHp);
                    if (scanEnemyInfo.isDead)
                    {
                        scanEnemy.scanEnemy.GetComponent<Animator>().SetTrigger("Die");
                    }
                }
                else if (scanEnemy.scanEnemy.GetComponent<BlueCost>())// 성이면
                {
                    BlueCastleBar.curHp -= unitInfo.damage;
                }
                else if (scanEnemy.scanEnemy.GetComponent<RedCost>())
                {
                    RedCastleBar.curHp -= unitInfo.damage;
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
        }


        unitInfo.atkDelay = unitInfo.atkCooltime;
    }

    public void Knockback(string team, Animator animator)
    {
        UnitInfo unitInfo = animator.GetComponent<UnitInfo>();
        UnitInfo enemyInfo;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(team);
        foreach (GameObject enemy in enemys)
        {
            enemyInfo = enemy.GetComponent<UnitInfo>();
            if (Mathf.Abs(enemy.transform.position.x - animator.transform.position.x) <= 3f && animator.transform.position.y == enemy.transform.position.y)
            {
                if (enemyInfo)
                {
                    enemyInfo.curHp -= unitInfo.damage;
                    enemy.GetComponent<HpBarController>().SetHealth(enemyInfo.curHp, enemyInfo.maxHp);
                    if (enemyInfo.isDead)
                    {
                        enemy.GetComponent<Animator>().SetTrigger("Die");
                    }
                    else
                    {
                        enemy.GetComponent<Animator>().SetTrigger("Hit");
                        enemyInfo.isHit = true;
                    }

                }
                else if (enemy.GetComponent<BlueCost>())// 성이면
                {
                    BlueCastleBar.curHp -= unitInfo.damage;
                }
                else if (enemy.GetComponent<RedCost>())
                {
                    RedCastleBar.curHp -= unitInfo.damage;
                }
            }
        }
    }

}
