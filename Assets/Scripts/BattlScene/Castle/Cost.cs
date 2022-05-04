using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cost : MonoBehaviour
{
    public int curCost;
    public int plusCost;
    public int maxCost;
    public BattleManager battleManager;
    public CastleInfo castleInfo;
    public Text requiredCostText;
    //public Text populationText;

    protected virtual void Start()
    {
        maxCost = 10;
        curCost = 0;
        battleManager = GameObject.Find("Master").GetComponent<BattleManager>();
        castleInfo = GetComponent<CastleInfo>();
        StartCoroutine("AddCost");
        if (requiredCostText)
            requiredCostText.text = "" + maxCost;
        castleInfo.maxPopulation = castleInfo.populationLevel * 10;
    }

    protected virtual IEnumerator AddCost()
    {

        while (!battleManager.stageEnd)
        {
            if (curCost < maxCost)
            {
                int currentCost;
                currentCost = curCost + CostPlus(castleInfo.castleLevel);

                if (currentCost >= maxCost)
                {
                    curCost = maxCost;
                }
                else
                {
                    curCost = currentCost;
                }

            }

            yield return new WaitForSeconds(2);
        }
    }

    public int CostPlus(int CastleLevel)
    {
        switch (CastleLevel)
        {
            case 1:
                plusCost = 1;
                maxCost = 10;
                break;
            case 2:
                plusCost = 2;
                maxCost = 20;
                break;
            case 3:
                plusCost = 4;
                maxCost = 40;
                break;
            case 4:
                plusCost = 6;
                maxCost = 60;
                break;
            case 5:
                plusCost = 10;
                maxCost = 100;
                break;
            case 6:
                plusCost = 14;
                maxCost = 160;
                break;
            case 7:
                plusCost = 18;
                maxCost = 260;
                break;
            case 8:
                plusCost = 24;
                maxCost = 410;
                break;
            case 9:
                plusCost = 30;
                maxCost = 680;
                break;

        }
        if (requiredCostText)
            requiredCostText.text = "" + maxCost;
        return plusCost;
    }


    public void Cancel()
    {
        if (Input.GetKeyDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
