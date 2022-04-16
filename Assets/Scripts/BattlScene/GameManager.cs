using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnitSpriteManager unitSpriteManager;
    public int bluePath;
    int redPath;

    public int blueUnitLevel;
    static public int blueCurUnitNumber;
    public int blueMaxUnitNumber;

    public int redUnitLevel;
    static public int redCurUnitNumber;
    public int redMaxUnitNumber;

    public int blueCastleLevel;
    public int redCastleLevel;

    public GameObject swardPrefab;
    public GameObject archerPrefab;
    public GameObject armouredSwardPrefab;
    public GameObject cavalryPrefab;
    public GameObject patrolPrefab;
    public GameObject royalGuardPrefab;
    public GameObject shieldPrefab;
    public GameObject spearManPrefab;
    public GameObject artilleryManPrefab;
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
    public int BCost;
    public int RCost;

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

        for (int i = 0; i < UnitBox.selectedUnitNumber; i++)
        {
            unitSlot[i].GetComponent<Image>().sprite = SlotSetting(unitSlot[i], i);
            unitSlot[i].GetComponent<SlotScript>().isUnit = true;
        }
        for (int i = UnitBox.selectedUnitNumber; i < PlayerData.unlockUnitNumber; i++)
        {
            unitSlot[i].GetComponent<Image>().sprite = empty;
        }
    }


    // Update is called once per frame
    void Update()
    {

        BCost = blueCost.cost;
        RCost = redCost.cost;

        if (stageEnd)
        {
            Result(win);
        }

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
        if (blueCost.cost == blueCost.maxCost)
        {
            blueCost.cost -= blueCost.maxCost;
            blueCastleLevel += 1;
        }
    }
    public void UnitCount()
    {
        if (blueCost.cost >= blueUnitLevel * 10 && blueUnitLevel < 4)
        {
            blueCost.cost -= blueUnitLevel * 10;
            blueUnitLevel += 1;
            unitCountCost.text = "" + blueUnitLevel * 10;
            blueMaxUnitNumber = blueUnitLevel * 10;
        }

    }

    public void SwardButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 3)
        {
            GameObject target = Instantiate(swardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 3;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void ArcherButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 5)
        {
            GameObject target = Instantiate(archerPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 5;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void ShieldButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 20)
        {
            GameObject target = Instantiate(shieldPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 20;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void ArmouredSwardButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 7)
        {
            GameObject target = Instantiate(armouredSwardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 7;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void PatrolButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 11)
        {
            GameObject target = Instantiate(patrolPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 11;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void SpearManButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 15)
        {
            GameObject target = Instantiate(spearManPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 15;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }
    public void Cavalry()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 30)
        {
            GameObject target = Instantiate(cavalryPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 30;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);

        }
    }
    public void ArtilleryMan()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 30)
        {
            GameObject target = Instantiate(artilleryManPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 30;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);

        }
    }
    public void RoyalGuard()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 50)
        {
            GameObject target = Instantiate(royalGuardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 50;
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
    }

    public void Result(bool win)
    {
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("Blue");
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Red");
        if (win)
        {
            hpCanvas.SetActive(false);
            controlSet.SetActive(false);
            AllUnitEnable(playerUnits, enemyUnits);
            resetButton.SetActive(true);
            victory.SetActive(true);

        }
        else
        {
            hpCanvas.SetActive(false);
            controlSet.SetActive(false);
            AllUnitEnable(playerUnits, enemyUnits);
            resetButton.SetActive(true);
            defeat.SetActive(true);
        }
    }


    public void AllUnitEnable(GameObject[] playerUnits, GameObject[] enemyUnits)
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

    public GameObject CreateUnitPosition(GameObject target)
    {
        child = Instantiate(bluePosition);
        child.transform.SetParent(canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(40, BluePathY(bluePath), 0) * canvasObject.GetComponent<RectTransform>().localScale.x;
        // Debug.Log("a : " + child.GetComponent<RectTransform>().position);
        child.GetComponent<BluePosition>().target = target;
        return child;
    }

    public float BluePathY(int bluePath)
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


    public Sprite SlotSetting(GameObject gameObject, int idx)
    {
        int id = UnitBox.selectedUnitIds[idx];
        int tribe, unit, level;
        tribe = id / 10000;
        id %= 10000;
        unit = id / 100;
        id %= 100;
        level = id;
        SlotScript slotScript = gameObject.GetComponent<SlotScript>();
        switch (tribe)
        {
            case 1:
                switch (unit)
                {
                    case 0:
                        gameObject.GetComponent<Image>().sprite = unitSpriteManager.blueSwardList[level];
                        slotScript.rawSprite = unitSpriteManager.blueSwardList[level];
                        slotScript.cost = 3;
                        slotScript.limitStateSprite = unitSpriteManager.blueSwardOffList[level];
                        slotScript.coolTime = 5f;
                        gameObject.tag = "Sward";
                        break;
                    case 1:
                        gameObject.GetComponent<Image>().sprite = unitSpriteManager.blueArcherList[level];
                        slotScript.rawSprite = unitSpriteManager.blueArcherList[level];
                        slotScript.cost = 5;
                        slotScript.limitStateSprite = unitSpriteManager.blueArcherOffList[level];
                        slotScript.coolTime = 6f;
                        gameObject.tag = "Archer";
                        break;
                    case 2:
                        gameObject.GetComponent<Image>().sprite = unitSpriteManager.blueArmouredSwardList[level];
                        slotScript.rawSprite = unitSpriteManager.blueArmouredSwardList[level];
                        slotScript.cost = 7;
                        slotScript.limitStateSprite = unitSpriteManager.blueArmouredSwardOffList[level];
                        slotScript.coolTime = 7f;
                        gameObject.tag = "ArmouredSward";
                        break;
                }
                break;
        }
        return gameObject.GetComponent<Image>().sprite;
    }
}
