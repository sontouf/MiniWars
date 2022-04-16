using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public RedCost redCost;
    int pattern;

    public GameObject swardPrefab;
    public GameObject archerPrefab;
    public GameObject armouredSwardPrefab;
    public GameObject cavalryPrefab;
    public GameObject patrolPrefab;
    public GameObject royalGuardPrefab;
    public GameObject shieldPrefab;
    public GameObject spearManPrefab;
    public GameObject artilleryMan;

    public int redPath;

    public GameManager gameManager;

    public GameObject redPosition;
   
    public GameObject canvasObject;
    public GameObject child;


    public int pattern2Count;
    public int pattern3Count;

    public int nextPattern;
    // Start is called before the first frame update
    void Start()
    {
        pattern = 0;
        SetPattern();
    }

    // pattern ;

    // cost를 8까지 모으고 궁수와 검사를 한꺼번에 소환.
    IEnumerator ArcherAndSward()
    {
        bool patternEnd = false;
        while (!patternEnd && !gameManager.stageEnd)
        {
            if (redCost.cost >= 8 && GameManager.redCurUnitNumber < gameManager.blueMaxUnitNumber)
            {
                redPath = Random.Range(-1, 2);
                int rand = Random.Range(0, 2);
                GameObject target;
                switch (rand)
                {
                    case 0:
                        target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                        redCost.cost -= 3;
                        GameManager.redCurUnitNumber += 1;
                        target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                        break;
                    case 1:
                        target = Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                        redCost.cost -= 5;
                        GameManager.redCurUnitNumber += 1;
                        target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                        break;
                }
                if (redCost.cost >= 5 && GameManager.redCurUnitNumber < gameManager.redMaxUnitNumber)
                {
                    redPath = Random.Range(-1, 2);
                    int nextRand = Random.Range(0, 3);
                    switch (nextRand)
                    {
                        case 0:
                            target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                            redCost.cost -= 3;
                            GameManager.redCurUnitNumber += 1;
                            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                            break;
                        case 1:
                            target = Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                            redCost.cost -= 5;
                            GameManager.redCurUnitNumber += 1;
                            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                            break;
                        case 2:
                            break;
                    }
                }
                patternEnd = true;

            }

            yield return new WaitForSeconds(1.5f);
        }

        SetPattern();
    }

    // 6까지 모으고 검사 2명 소환.
    IEnumerator SwardAndSward()
    {
        bool patternEnd = false;
        while (!patternEnd && !gameManager.stageEnd)
        {
            if (redCost.cost >= 6 && GameManager.redCurUnitNumber < gameManager.blueMaxUnitNumber)
            {
                GameObject target;
                for (int i = 0; i < 2; i++)
                {
                    redPath = Random.Range(-1, 2);
                    target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                    redCost.cost -= 3;
                    GameManager.redCurUnitNumber += 1;
                    target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                }
                patternEnd = true;

            }
            yield return new WaitForSeconds(1.5f);
        }
        SetPattern();
    }

    IEnumerator UpUnitLevel()
    {
        bool patternEnd = false;
        while (!patternEnd && !gameManager.stageEnd)
        {
            if (redCost.cost >= gameManager.redUnitLevel * 10)
            {
                UpUnit();
                patternEnd = true;
            }

            yield return  new WaitForSeconds(1.5f);
        }
        SetPattern();
    }

    IEnumerator UpCastleLevel()
    {
        bool patternEnd = false;
        while (!patternEnd && !gameManager.stageEnd)
        {
            if (redCost.cost == redCost.maxCost)
            {
                UpCastle();
                patternEnd = true;
            }

            yield return new WaitForSeconds(1.5f);
        }
        SetPattern();
    }

    IEnumerator SaveCost()
    {
        bool patternEnd = false;
        while (!patternEnd && !gameManager.stageEnd)
        {
            if (redCost.cost >= gameManager.redCost.CostPlus(gameManager.redCastleLevel) * 0.8f)
            {
                patternEnd = true;
            }
            yield return new WaitForSeconds(1.5f);
        }
        SetPattern();
    }


    //=========================================Up=========================
    public void UpCastle()
    {
        gameManager.redCastleLevel++;
        redCost.cost = 0;
    }
    public void UpUnit()
    {
        redCost.cost -= gameManager.redUnitLevel * 10;
        gameManager.redUnitLevel++;
        gameManager.redMaxUnitNumber = gameManager.redUnitLevel * 10;
    }


    // ====================================================================
    public GameObject CreateUnitPosition(GameObject target, int redPath)
    {
        child = Instantiate(redPosition);
        child.transform.SetParent(canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(134, RedPathY(redPath), 0) * canvasObject.GetComponent<RectTransform>().localScale.x;
        child.GetComponent<RedUnitPosition>().target = target;
        child.GetComponent<RedUnitPosition>().redPath = RedPathY(redPath);
        return child;
    }


    public float RedPathY(int redPath)
    {
        float redPathY = 0;
        if (redPath == 2)
        {
            redPathY = 23.5f;
        }
        else if (redPath == 0)
        {
            redPathY = 15.7f;

        }
        else if (redPath == -2)
        {
            redPathY = 8;
        }
        return redPathY;
    }

    public void SetPattern()
    {
        int firstP = Random.Range(0, 20);
        if (firstP >= 0 && firstP < 6)
        {
            pattern = 0;
        }
        else if (firstP >= 6 && firstP < 12)
        {
            pattern = 1;
        }
        else if (firstP >= 12 && firstP < 16&& GameManager.redCurUnitNumber > 5)
        {
            pattern = 3;
        }
        else if (firstP >= 16 && firstP < 20)
        {
            pattern = 4;
        }

        if (GameManager.redCurUnitNumber >= gameManager.redMaxUnitNumber * 0.7f && gameManager.redUnitLevel < 4)
        {
            int p = Random.Range(0, 12);
            if (p >= 0 && p < 7)
            {
                Debug.Log("a : " + GameManager.redCurUnitNumber + " , " + gameManager.redMaxUnitNumber * 0.7f);
                pattern = 2;
            }
            else if (p >= 7 && p <10)
            {
                int pp = Random.Range(0, 2);
                if (pp == 0)
                {
                    pattern = 1;
                }
                else if (pp == 1)
                {
                    pattern = 0;
              
                }
            }
            else
            {
                pattern = 4;
            }
        }
        else if(redCost.cost >= redCost.maxCost * 0.5f && gameManager.redCastleLevel < 5 && GameManager.redCurUnitNumber > 5 )
        { 
            int p = Random.Range(0, 12);
            if (p >= 0 && p < 6 )
            {
                pattern = 3;
            }
            else if (p >= 6 && p < 10)
            {
                int pp = Random.Range(0, 2);
                if (pp == 0)
                {
                    pattern = 1;
                }
                else if (pp == 1)
                {
                    pattern = 0;
                }
            }
            else
            {
                pattern = 4;
            }
        }
        if (redCost.cost == redCost.maxCost)
        {
            pattern = 3;
        }
        if (!gameManager.stageEnd)
        {
            switch (pattern)
            {
                case 0:
                    StartCoroutine("ArcherAndSward");
                    break;
                case 1:
                    StartCoroutine("SwardAndSward");
                    break;
                case 2:
                    StartCoroutine("UpUnitLevel");
                    break;
                case 3:
                    StartCoroutine("UpCastleLevel");
                    break;
                case 4:
                    StartCoroutine("SaveCost");
                    break;
            }
        }
    }

}
