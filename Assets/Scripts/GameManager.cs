using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

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
        redMaxUnitNumber = 10;
    }


    // Update is called once per frame
    void Update()
    {
        if (blueUnitLevel < 6)
        {
            blueMaxUnitNumber = blueUnitLevel * 10;
        }
        else
        {
            blueUnitLevel = 5;
        }

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
        if ( blueCost.cost >= blueUnitLevel * 10)
        {
            blueCost.cost -= blueUnitLevel * 10;
            blueUnitLevel += 1;
        }

    }

    public void SwardButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 3)
        {
            Instantiate(swardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 3;
        }
    }
    public void ArcherButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 5)
        {
            Instantiate(archerPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 5;
        }
    }
    public void ShieldButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 20)
        {
            Instantiate(shieldPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 15;
        }
    }
    public void ArmouredSwardButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 7)
        {
            Instantiate(armouredSwardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 7;
        }
    }
    public void PatrolButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 11)
        {
            Instantiate(patrolPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 11;
        }
    }
    public void SpearManButton()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 15)
        {
            Instantiate(spearManPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 15;
        }
    }
    public void Cavalry()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 30)
        {
            Instantiate(cavalryPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 25;

        }
    }
    public void RoyalGuard()
    {
        if (blueCurUnitNumber < blueMaxUnitNumber && blueCost.cost >= 50)
        {
            Instantiate(royalGuardPrefab, new Vector3(-18, bluePath, 0), Quaternion.identity);
            blueCurUnitNumber += 1;
            blueCost.cost -= 50;
        }
    }

    public void Result(bool win)
    {
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("Blue");
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Red");
        if (win)
        {
            controlSet.SetActive(false);
            AllUnitEnable(playerUnits, enemyUnits);
            resetButton.SetActive(true);
            victory.SetActive(true);

        }
        else
        {
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
}
