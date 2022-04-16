using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool isHit;
    public GameObject positionObject;

    public Slider child;
    Slider hp;
    public HpBarController hpBarController;
    private GameObject parentObject;

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
        parentObject = GameObject.Find("Canvas");
        if (gameObject.layer == 8)
        {
            hp = Resources.Load<Slider>("Prefabs/BlueSlider");
        }
        else
        {
            hp = Resources.Load<Slider>("Prefabs/RedSlider");
        }
        child = Instantiate(hp);
        child.transform.SetParent(parentObject.transform);
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);
    }
    protected virtual void Update()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
        if (curHp <= 0 && !isDead)
        {
            animator.SetTrigger("Die");
            isDead = !isDead;
        }
        if (child)
        {
            child.transform.position = Camera.main.WorldToScreenPoint(transform.GetChild(0) .position);
        }
    }
}
