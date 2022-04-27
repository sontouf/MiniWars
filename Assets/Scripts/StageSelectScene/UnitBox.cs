using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitBox : MonoBehaviour
{
    //public PlayerData playerData;
    public UnitSpriteManager unitSpriteManager;

    public GameObject openPage;


    public GameObject[] pages = new GameObject[3];
    /*public GameObject page2;
    public GameObject page3;*/


    public List<GameObject> pageUnits = new List<GameObject>(); // page내의 유닛 30개 gameObject;
    public List<int> pageUnitSpriteIds = new List<int>(30); // 각 슬롯의 그림 id 저장.
    public List<GameObject> selectedUnits = new List<GameObject>(); // 선택된 유닛 게임오브젝트 .
    static public int[] selectedUnitIds = new int[8]; // 선택된 유닛 gameManager에서 실행시킬때 필요한 id 정보들.
    public Dictionary<GameObject, int> pageUnitIds = new Dictionary<GameObject, int>(30); // 버튼을 눌렀을때 그 눌린 버튼 게임오브젝트가 인수로 넘어가 id 반환.


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
        openPage = pages[0];
    }

    private void Update()
    {
        selectedNumber = selectedUnitNumber;
    }


    // page 관련 함수들
    public void Left()
    {
        if (openPage == pages[1])
        {
            pages[0].SetActive(true);
            pages[1].SetActive(false);
            openPage = pages[0];
        }
        else if (openPage == pages[2])
        {
            pages[1].SetActive(true);
            pages[2].SetActive(false);
            openPage = pages[1];
        }
    }
    public void Right()
    {
        if (openPage == pages[0])
        {
            pages[1].SetActive(true);
            pages[0].SetActive(false);
            openPage = pages[1];
        }
        else if (openPage == pages[1])
        {
            pages[2].SetActive(true);
            pages[1].SetActive(false);
            openPage = pages[2];
        }
    }
    //--------------------------------------


    public void SettingUnitBox() // pageUnits 랑 selectedUnits은 에디터상에서 원소를 추가해주었다. 30개 8개 이미 있다고 생각하기.
    {
        int count = PlayerData.unitObjectList.Count; // 플레이어가 갖고 있는 유닛수를 가져온다.
        for (int i = 0; i <  PlayerData.unlockUnitNumber; i++) // battle 에 갖고 갈수있는 유닛의 수만큼 empty해준다.
        {
            selectedUnits[i].GetComponent<Image>().sprite = empty;
        }

        for (int i = 0; i< count; i++) // 플레이어 정보에 따라 유닛 sprite를 가지고 온다.
        {
            pageUnits[i].GetComponent<Image>().sprite = UnitBoxController(PlayerData.unitObjectList[i]); // unitObjectList에는 int값이 저장되어 있다.
            pageUnitSpriteIds[i] = PlayerData.unitObjectList[i];
        }
        for (int i = count; i < 30; i++) // 30개중 갖고있는 유닛외에는 다 empty 처리해준다.
        {
            pageUnits[i].GetComponent<Image>().sprite = empty;
        }
        for (int i = 0; i < count; i++)
        {
            pageUnitIds[pageUnits[i]] = pageUnitSpriteIds[i];
        }
/*        for (int i = 0; i < 8; i++)
        {
            selectedUnitIds.Add(0);
        }*/
    }


    public Sprite UnitBoxController(int unitId) // unitId를 통해 해당 sprite 갖고온다.
    {
        int tribe, unit, level;
        tribe = unitId / 10000;
        // unitId %= 10000;
        unit = (unitId % 10000) / 100;
        //unitId %= 100;
        level = (unitId % 100);
        if (tribe == 1) // sprite 초기화작업.
            sprite = unitSpriteManager.unitOnList[unit][level];

        return sprite;
    }


}
