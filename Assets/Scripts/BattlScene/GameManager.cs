using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour // gameManager 이긴한데 Battle manager 가 더 맞는 느낌.
{
    //public UnitSpriteManager unitSpriteManager; // unit slot sprite 배치를 위해 sprite manager를 받아온다.
    public int bluePath;
    int redPath;

    //----------- battle 중 upgrade에 필요한 변수들.
    public int blueUnitLevel;
    static public int blueCurUnitNumber;
    public int blueMaxUnitNumber;

    public int redUnitLevel;
    static public int redCurUnitNumber;
    public int redMaxUnitNumber;

    public int blueCastleLevel;
    public int redCastleLevel;

    public GameObject bluePosition;

    public GameObject canvasObject;
    public GameObject child; // bluePosition

    public GameObject hpCanvas;
    public GameObject victory;
    public GameObject defeat;
    public GameObject resetButton;
    public GameObject controlSet;
    public bool win;
    public bool stageEnd;

    public BlueCost blueCost;
    public RedCost redCost;
   /* public int BCost;
    public int RCost;*/

    public Text unitCountCost;


    public Sprite empty;
    public List<GameObject> unitSlot = new List<GameObject>(8);


    

    // Start is called before the first frame update
    void Start()
    {
        bluePath = 0;
        redPath = 0;
        blueCurUnitNumber = 0;
        blueMaxUnitNumber = 10;
        blueCastleLevel = 1;
        blueUnitLevel = 1;
        redCastleLevel = 1;
        redUnitLevel = 1;
        redCurUnitNumber = 0;
        redMaxUnitNumber = 10;
        unitCountCost.text = "" + blueUnitLevel * 10;
        blueMaxUnitNumber = blueUnitLevel * 10;

        // 왼쪽 유닛 선택창의 sprite 배치 코드
        for (int i = 0; i < UnitBox.selectedUnitNumber; i++) // 이전 페이지에서 선택된 유닛 순서대로 battle씬에서 배치하고자 한다.
        {
            unitSlot[i].GetComponent<Image>().sprite = SlotSetting(unitSlot[i], i); 
            unitSlot[i].GetComponent<SlotScript>().isUnit = true;
        }
        for (int i = UnitBox.selectedUnitNumber; i < PlayerData.unlockUnitNumber; i++) // 선택 안된애들은 empty sprite를 가지게 된다.
        {
            unitSlot[i].GetComponent<Image>().sprite = empty;
        }
    }


    // Update is called once per frame
    void Update()
    {
/*
        BCost = blueCost.cost;
        RCost = redCost.cost;*/
        if (stageEnd)
            Result(win);
    }

    // choice Path
    public void topPath()
    {
        bluePath = 2;
    }
    public void middlePath()
    {
        bluePath = 0;
    }
    public void bottomPath()
    {
        bluePath = -2;
    }


    // Upgrade Castle && UnitCount
    public void Castle()
    {
        if (!stageEnd && blueCost.cost == blueCost.maxCost)
        {
            blueCost.cost -= blueCost.maxCost;
            blueCastleLevel += 1;
        }
    }
    public void UnitCount()
    {
        if (!stageEnd && blueCost.cost >= blueUnitLevel * 10 && blueUnitLevel < 4)
        {
            blueCost.cost -= blueUnitLevel * 10;
            blueUnitLevel += 1;
            unitCountCost.text = "" + blueUnitLevel * 10;
            blueMaxUnitNumber = blueUnitLevel * 10;
        }

    }


    // --------------------------------------------------------------------------------
    // Result function
    public void Result(bool win)
    {
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("Blue");
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Red");

        hpCanvas.SetActive(false);
        controlSet.SetActive(false);
        AllUnitEnableOff(playerUnits, enemyUnits);
        resetButton.SetActive(true);
        if (win)
            victory.SetActive(true);
        else
            defeat.SetActive(true);
    }


    public void AllUnitEnableOff(GameObject[] playerUnits, GameObject[] enemyUnits)
    {
        foreach (GameObject playerUnit in playerUnits)
        {
            if (playerUnit.GetComponent<Animator>())
            {
                playerUnit.GetComponent<Animator>().enabled = false;
            }
        }
        foreach (GameObject enemyUnit in enemyUnits)
        {
            if (enemyUnit.GetComponent<Animator>())
            {
                enemyUnit.GetComponent<Animator>().enabled = false;
            }
        }
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(0);
    }
    // --------------------------------------------------------------------------------




    public GameObject CreateUnitPosition(GameObject target)
    {
        // MiniMap의 유닛 위치를 생성해주는 함수이다.인자로 위치표시가 필요한 target이 들어온다.
        child = Instantiate(bluePosition);
        child.transform.SetParent(canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(40, BluePathY(bluePath), 0) * canvasObject.GetComponent<RectTransform>().localScale.x;
        // Debug.Log("a : " + child.GetComponent<RectTransform>().position);
        child.GetComponent<BluePosition>().target = target;
        return child;
    }

    float BluePathY(int bluePath)
    {
        float bluePathY = 0;
        if (bluePath == 2)
        {
            bluePathY = 23.5f;
        }
        else if (bluePath == 0)
        {
            bluePathY = 15.7f;

        }
        else if (bluePath == -2)
        {
            bluePathY = 8;
        }
        return bluePathY;
    }


   Sprite SlotSetting(GameObject gameObject, int idx) 
    {
        // Battle 시작시 왼쪽에 나열된 유닛창에 대한 정보. 한 슬롯에 대해 적용된다.
        // 어떠한 한 슬롯이 인자로 들어오고 그 슬롯의 위치인 idx가 인자로 들어와서 UnitBox에서 정보를 받아와 순서대로 sprite가 적용이 된다.
        int id = UnitBox.selectedUnitIds[idx];
        int tribe, unit, level;
        tribe = id / 10000;
        id %= 10000;
        unit = id / 100;
        id %= 100;
        level = id;
        SlotScript slotScript = gameObject.GetComponent<SlotScript>();
        if (tribe == 1)
        {
                // battle 시작시 화면 초기화 작업 시작.
                // slot 창 꾸미기.
                gameObject.GetComponent<Image>().sprite = UnitSpriteManager.unitOnList[unit][level];
                slotScript.rawSprite = UnitSpriteManager.unitOnList[unit][level];
                slotScript.cost = MyType.UnitCost[unit];
                slotScript.limitStateSprite = UnitSpriteManager.unitOffList[unit][level];
                slotScript.coolTime = MyType.UnitCoolTime[unit];
                gameObject.tag = MyType.UnitTypeFromString.FirstOrDefault(x=>x.Value == (MyType.UnitType)unit).Key;
        }
        return gameObject.GetComponent<Image>().sprite;
    }
}
