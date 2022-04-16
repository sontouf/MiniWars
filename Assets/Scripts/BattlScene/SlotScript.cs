using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerClickHandler
{
    public Image coolTimeImage;

    string tagName;
    public GameManager gameManager;
    public int cost;
    public Sprite limitStateSprite;
    public bool coolTimelimitState;
    public bool coolTiming;
    public bool activeButton;
    public bool isUnit;
    public float coolTime;


    public Sprite rawSprite;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && !coolTimelimitState && !coolTiming && activeButton)
        {
            tagName = gameObject.tag;
            switch (tagName)
            {
                case "Sward":
                    gameManager.SwardButton();
                    break;
                case "Archer":
                    gameManager.ArcherButton();
                    cost = 5;
                    break;
                case "ArmouredSward":
                    gameManager.ArmouredSwardButton();
                    cost = 7;
                    break;
            }
            coolTimelimitState = !coolTimelimitState;
            coolTiming = !coolTiming;
        }
    }

    private void Update()
    {
        if (cost > gameManager.blueCost.cost && isUnit)
        {
            gameObject.GetComponent<Image>().sprite = limitStateSprite;
            activeButton = false;
        }
        else if (cost <= gameManager.blueCost.cost && isUnit)
        {
            gameObject.GetComponent<Image>().sprite = rawSprite;
            activeButton = true;
        }
        if (coolTimelimitState && coolTiming && isUnit)
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
