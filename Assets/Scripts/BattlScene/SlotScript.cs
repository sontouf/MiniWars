﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerClickHandler
{
    // gameManager에서 쓰이는 코드. 
    // 또한 unit slot마다 slotscript를 가지고 있다. 각 슬롯마다 사용된 순간과 쿨타임과 조건이 다 다를수있기 때문이다.
    public Image coolTimeImage;

    public string tagName;
    public GameManager gameManager;
    public int cost; // 이 슬롯에 해당하는 유닛의 cost 값.
    public Sprite limitStateSprite;
    public bool coolTimelimitState;
    public bool coolTiming;
    public bool activeButton;
    public bool isUnit;
    public float coolTime;

    public ButtonScript buttonScript;


    public Sprite rawSprite;


    public void Start()
    {
        tagName = gameObject.tag;
        if (tagName != "Untagged")
            cost = MyType.UnitCostFromString[tagName];
    }
    public void OnPointerClick(PointerEventData pointerEventData) // 쿨타임아니면 가능. 버튼을 눌렀을시 발생하는 이벤트코드
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && !coolTimelimitState && !coolTiming && activeButton)
        {
            // button 클래스화 시킴.
            //tagName = gameObject.tag;
            buttonScript.Button(MyType.UnitTypeFromString[tagName]);
            //cost = MyType.UnitCostFromString[tagName];
            coolTimelimitState = !coolTimelimitState;
            coolTiming = !coolTiming;
        }
    }

    private void Update()  // sprite 이미지 변화때문에 update문 필요.
    {
        if (cost > gameManager.blueCost.curCost && isUnit) // 돈없으면 비활성화.
        {
            gameObject.GetComponent<Image>().sprite = limitStateSprite;
            activeButton = false;
        }
        else if (!gameManager.stageEnd && cost <= gameManager.blueCost.curCost && isUnit) // 돈있으면 활성화.
        {
            gameObject.GetComponent<Image>().sprite = rawSprite;
            activeButton = true;
        }
        if (!gameManager.stageEnd && coolTimelimitState && coolTiming && isUnit) // 쿨타임중이면 버튼 클릭해도 버튼코드 실행안되게 하기.
        {
            coolTimeImage.enabled = true;
            coolTimelimitState = !coolTimelimitState;
            StartCoroutine(CoolTime(coolTime));

        }

    }

    IEnumerator CoolTime(float cooltime)
    {
        float maxCoolTime = cooltime;
        while (cooltime > 0f)
        {
            cooltime -= Time.deltaTime;
            coolTimeImage.fillAmount = (cooltime / maxCoolTime);
            yield return new WaitForFixedUpdate();

        }
        coolTimeImage.enabled = false;
        coolTiming = !coolTiming;
    }
}
