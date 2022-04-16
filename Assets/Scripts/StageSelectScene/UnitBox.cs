using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitBox : MonoBehaviour
{
    public PlayerData playerData;
    public UnitSpriteManager unitSpriteManager;

    public GameObject openPage;


    public GameObject page1;
    public GameObject page2;
    public GameObject page3;


    public List<GameObject> pageUnits = new List<GameObject>(); // page내의 유닛 30개 gameObject;
    public List<int> pageUnitSpriteIds = new List<int>(); // 각 슬롯의 그림 id 저장.
    public List<GameObject> selectedUnits = new List<GameObject>(); // 선택된 유닛 게임오브젝트 .
    static public List<int> selectedUnitIds = new List<int>(); // 선택된 유닛 gameManager에서 실행시킬때 필요한 id 정보들.
    public Dictionary<GameObject, int> pageUnitIds = new Dictionary<GameObject, int>(); // 버튼을 눌렀을때 그 눌린 버튼 게임오브젝트가 인수로 넘어가 id 반환.


    static public int selectedUnitNumber; // 몇명 선택되었나.
    public int selectedNumber;
    Sprite sprite;
    int spriteNumber;
    public Sprite empty;
    public Sprite lockSprite;


    public void Start()
    {
        selectedUnitNumber = 0;
        SettingUnitBox();

        openPage = page1;
  
        
    }

    private void Update()
    {
        selectedNumber = selectedUnitNumber;

    }

    public void Left()
    {
        if (openPage == page2)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            openPage = page1;
        }
        else if (openPage == page3)
        {
            page2.SetActive(true);
            page3.SetActive(false);
            openPage = page2;
        }
    }
    public void Right()
    {
        if (openPage == page1)
        {
            page2.SetActive(true);
            page1.SetActive(false);
            openPage = page2;
        }
        else if (openPage == page2)
        {
            page3.SetActive(true);
            page2.SetActive(false);
            openPage = page3;
        }
    }

    public void SettingUnitBox()
    {
        int count = PlayerData.unitObjectList.Count;
        for (int i =0; i <  PlayerData.unlockUnitNumber; i++)
        {
            selectedUnits[i].GetComponent<Image>().sprite = empty;
        }

        for (int i = 0; i< count; i++)
        {
            pageUnits[i].GetComponent<Image>().sprite = UnitBoxController(PlayerData.unitObjectList[i]);
            pageUnitSpriteIds.Add(PlayerData.unitObjectList[i]);
        }
        for (int i = count; i < 30; i++)
        {
            pageUnits[i].GetComponent<Image>().sprite = empty;
        }
        for (int i = 0; i < pageUnitSpriteIds.Count; i++)
        {
            pageUnitIds.Add(pageUnits[i], pageUnitSpriteIds[i]);
        }
        for (int i = 0; i < 8; i++)
        {
            selectedUnitIds.Add(0);
        }
    }


    public Sprite UnitBoxController(int unitId)
    {
        int tribe, unit, level;
        tribe = unitId / 10000;
        unitId %= 10000;
        unit = unitId / 100;
        unitId %= 100;
        level = unitId;


        switch (tribe)
        {
            case 1:
                switch (unit)
                {
                    case 0:
                        sprite = unitSpriteManager.blueSwardList[level];
                        break;
                    case 1:
                        sprite = unitSpriteManager.blueArcherList[level];
                        break;
                    case 2:
                        sprite = unitSpriteManager.blueArmouredSwardList[level];
                        break;
                }
                break;
        }

        return sprite;
    }


}
