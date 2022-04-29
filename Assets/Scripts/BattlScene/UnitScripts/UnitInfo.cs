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

    public CastleInfo castleInfo;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        parentObject = GameObject.Find("Canvas");
        if (gameObject.layer == 8)
        {
            speed = 1;
            hp = Resources.Load<Slider>("Prefabs/BlueSlider");
            castleInfo = GameObject.Find("BlueCastle").GetComponent<BlueCastleInfo>();
        }
        else
        {
            speed = -1;
            hp = Resources.Load<Slider>("Prefabs/RedSlider");
            castleInfo = GameObject.Find("RedCastle").GetComponent<RedCastleInfo>();
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
            //castleInfo.curUnitNumber -= 1;
            isDead = !isDead;
        }
        if (child)
        {
            child.transform.position = Camera.main.WorldToScreenPoint(transform.GetChild(0) .position);
        }
    }
}
