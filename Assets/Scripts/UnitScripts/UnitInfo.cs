using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    public int maxHp;
    public int curHp;
    public int damage;
    public float speed;
    public Animator animator;
    public bool isDead;
    public float atkCooltime = 1;
    public float atkDelay;
    public int defence;


    protected virtual void Start()
    {
        if(gameObject.layer == 9)
        {
            speed = -1;
        }
        else if (gameObject.layer == 8)
        {
            speed = 1;
        }

        animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
    }
}
