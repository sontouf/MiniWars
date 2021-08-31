using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanEnemy : MonoBehaviour
{
    float distance;
    public GameObject scanEnemy;
    RaycastHit2D hit;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        FindUnit();
    }
    public GameObject FindUnit()
    {
        if (gameObject.layer == 8)
        {
            hit = Physics2D.Raycast(transform.position , Vector3.right, SetCalculate(), LayerMask.GetMask("Red"));
        }
        else if (gameObject.layer == 9)
        {
            hit = Physics2D.Raycast(transform.position , Vector3.left, SetCalculate(), LayerMask.GetMask("Blue"));

        }
        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<UnitInfo>()) // 성말고 유닛이면.
            {
                if (!hit.transform.GetComponent<UnitInfo>().isDead) // 그중 안 죽은 상태인 애;
                {
                    scanEnemy = hit.transform.gameObject;
                }
                else
                {
                    scanEnemy = null;
                }
            }
            else if (hit.transform.GetComponent<BlueCost>() || hit.transform.GetComponent<RedCost>()) // 성이면.
            {
                scanEnemy = hit.transform.gameObject;
            }
        }
        else
        {
            scanEnemy = null;
        }
        return scanEnemy;
    }

    public float SetCalculate()
    {
        if (GetComponent<Sward>())
        {
            distance = 1.1f;
        }
        else if (GetComponent<Spearman>())
        {
            distance = 1.3f;
        }
        else if (GetComponent<Shield>())
        {
            distance = 0.9f;
        }
        else if (GetComponent<RoyalGuard>())
        {
            distance = 1.3f;
        }
        else if (GetComponent<Patrol>())
        {
            distance = 0.8f;
        }
        else if (GetComponent<Cavalry>())
        {
            distance = 0.9f;
        }

        else if (GetComponent<ArmouredSward>())
        {
            distance = 0.9f;
        }
        else if (GetComponent<Archer>())
        {
            distance = 4f;
        }
        return distance;
    }

}
