using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public RedCost redCost;
    int pattern;
    float second;
    public GameObject swardPrefab;
    public GameObject archerPrefab;
    public GameObject armouredSwardPrefab;
    public GameObject cavalryPrefab;
    public GameObject patrolPrefab;
    public GameObject royalGuardPrefab;
    public GameObject shieldPrefab;
    public GameObject spearManPrefab;
    public GameObject artilleryMan;

    public RedCastleInfo redCastleInfo;

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
        second = redCost.waitForSecond;
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
            if (redCost.curCost >= 8 && GameManager.redCurUnitNumber < redCastleInfo.maxPopulation)
            { // 일단 8만큼 채움.
                redPath = Random.Range(-1, 2);
                int rand = Random.Range(0, 2);
                GameObject target;
                switch (rand)// 2마리 생산하긴 할건데 일단 궁수나 검사 랜덤으로 한명.
                {
                    case 0:
                        target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                        redCost.curCost -= 3;
                        GameManager.redCurUnitNumber += 1;
                        target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                        break;
                        /*                    case 1:
                                                target = Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                                                redCost.cost -= 5;
                                                GameManager.redCurUnitNumber += 1;
                                                target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                                                break;
                                        }
                                        if (GameManager.redCurUnitNumber < redCastleInfo.maxPopulation)
                                        {
                                            redPath = Random.Range(-1, 2);
                                            rand = Random.Range(0, 3);
                                            switch (rand) // 2번째 병사를 뽑을건데 안 뽑을수도 있긴함.
                                            {
                                                case 0:
                                                    target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                                                    redCost.cost -= 3;
                                                    GameManager.redCurUnitNumber += 1;
                                                    target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                                                    break;
                                                case 1:
                                                    target = Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                                                    if (redCost.cost >= 5)
                                                        redCost.cost -= 5;
                                                    else
                                                        redCost.cost -= 3;
                                                    GameManager.redCurUnitNumber += 1;
                                                    target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                                                    break;
                                            }
                                        }*/
                }
                        patternEnd = true;

                }

                yield return new WaitForSeconds(second);
            }
            //Debug.Log("pattern end");
            SetPattern();
        }

        // 6까지 모으고 검사 2명 소환.
        /*  IEnumerator SwardAndSward() // second초후에 끝나는 명령어.
          {
              bool patternEnd = false;
              while (!patternEnd && !gameManager.stageEnd)
              {
                  if (redCost.cost >= 6 && GameManager.redCurUnitNumber < redCastleInfo.maxPopulation)
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
                  yield return new WaitForSeconds(second);
              }
              //Debug.Log("pattern end");
              SetPattern();
          }

          IEnumerator ArmouredSwardAndSward()
          {
              bool patternEnd = false;
              GameObject target;
              while (!patternEnd && !gameManager.stageEnd)
              {
                  if (redCost.cost >= 7 && GameManager.redCurUnitNumber < redCastleInfo.maxPopulation)
                  {
                      redPath = Random.Range(-1, 2);
                      target = Instantiate(armouredSwardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                      redCost.cost -= 7;
                      GameManager.redCurUnitNumber += 1;
                      target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                  }
                  else if (redCost.cost >= 3 && GameManager.redCurUnitNumber < redCastleInfo.maxPopulation)
                  {
                      redPath = Random.Range(-1, 2);
                      target = Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                      redCost.cost -= 3;
                      GameManager.redCurUnitNumber += 1;
                      target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target, redPath * 2);
                      patternEnd = true;
                  }
                  yield return new WaitForSeconds(second);
              }
              //Debug.Log("pattern end");
              SetPattern();
          }

          IEnumerator UpUnitLevel()
          {
              bool patternEnd = false;
              while (!patternEnd && !gameManager.stageEnd)
              {
                  if (redCost.cost >= redCastleInfo.populationLevel * 10)
                  {
                      UpUnit();
                      patternEnd = true;
                  }

                  yield return  new WaitForSeconds(second);
              }
              //Debug.Log("UpUnitLevel End");
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

                  yield return new WaitForSeconds(second);
              }
              //Debug.Log("pattern end");
              SetPattern();
          }

          IEnumerator SaveCost() // 잔고 80%이상 될때까지 돈 모으기.
          {
              bool patternEnd = false;
              while (!patternEnd && !gameManager.stageEnd)
              {
                  if (redCost.cost >= gameManager.redCost.CostPlus(redCastleInfo.castleLevel) * 0.8f)
                  {
                      patternEnd = true;
                  }
                  yield return new WaitForSeconds(second);
              }
              //Debug.Log("pattern end");
              SetPattern();
          }
      */

        /*  //=========================================Up=========================
          public void UpCastle()
          {
              redCastleInfo.castleLevel++;
              redCost.cost = 0;
          }
          public void UpUnit()
          {
              redCost.cost -= redCastleInfo.populationLevel * 10;
              redCastleInfo.populationLevel++;
              redCastleInfo.maxPopulation = redCastleInfo.populationLevel * 10;
          }*/


        // ====================================================================
    GameObject CreateUnitPosition(GameObject target, int redPath)
    {
        child = Instantiate(redPosition);
        child.transform.SetParent(canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(134, RedPathY(redPath), 0) * canvasObject.GetComponent<RectTransform>().localScale.x;
        child.GetComponent<RedUnitPosition>().target = target;
        child.GetComponent<RedUnitPosition>().redPath = RedPathY(redPath);
        return child;
    }


    float RedPathY(int redPath)
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

    void SetPattern()
    {
        pattern = 0;
/*        //--------------------------------------- 인구수에 따른 판단.
        if (GameManager.redCurUnitNumber >= redCastleInfo.maxPopulation * 0.7f && redCost.maxCost >= redCastleInfo.populationLevel * 10)
        {
            pattern = 2; // 인구가 많으니 인구수 업을 해야겠다.
            if (GameManager.redCurUnitNumber >= redCastleInfo.maxPopulation * 0.85f)
                pattern = 2; // 아 인구너무 많아 인구 업!
            else if (redCost.curCost >= redCost.maxCost * 0.8f)
                pattern = 3; // 근데 돈도 많네? 성 업글하고 인구수 해결하자.
            else if (redCost.curCost >= redCost.maxCost * 0.3f)// 인구가 좀 많긴한데 돈 모아도 되겠다.
                pattern = 4;
        }
        else if (GameManager.redCurUnitNumber >= redCastleInfo.maxPopulation * 0.3f && redCost.maxCost >= redCastleInfo.populationLevel * 10)
        {
            pattern = Random.Range(0, 2); // 아 일단 병사들 뽑아야함.
            if (redCastleInfo.castleLevel > 1) // 혹시나 성업글 2이상이면 갑옷병 슬슬 뽑아보자.
                pattern = 5;
        }
        else // 인구수가 없거나 인구수가 많아도 성레벨이 딸려서 어차피 인구수 레벨업 못할경우. 
        {
            if (redCost.curCost <= redCost.maxCost * 0.3f) // 인구 없는데 돈도 없다.
                pattern = 4; // 돈 모으자.
            else if (GameManager.redCurUnitNumber >= redCastleInfo.maxPopulation * 0.8f) // 인구가 많아서 인구수 레벨업해야하는데 성레벨 딸리는 경우
                pattern = 3;
            else  //인구 없는데 돈은 있다.
                pattern = Random.Range(0, 2); // 돈은 좀 있으니 병사 뽑자.
        }
*/
        if (!gameManager.stageEnd)
        {
            switch (pattern)
            {
                case 0:
                    Debug.Log("pattern : ArcherAndSward");
                    StartCoroutine("ArcherAndSward");
                    break;
                case 1:
                    Debug.Log("pattern : SwardAndSward");
                    //StartCoroutine("SwardAndSward");
                    break;
                case 2:
                    Debug.Log("pattern : UpUnitLevel");
                   // StartCoroutine("UpUnitLevel");
                    break;
                case 3:
                    Debug.Log("pattern : UpCastleLevel");
                    //StartCoroutine("UpCastleLevel");
                    break;
                case 4:
                    Debug.Log("pattern : SaveCost");
                    //StartCoroutine("SaveCost");
                    break;
                case 5:
                    Debug.Log("pattern : ArmouredSwardAndSward");
                    //StartCoroutine("ArmouredSwardAndSward");
                    break;
            }
        }
    }
}

