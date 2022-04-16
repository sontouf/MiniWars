using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCost : MonoBehaviour
{
    public int cost;
    public int plusCost;
    public int maxCost;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        maxCost = 10;
        cost = 0;
        StartCoroutine("AddCost");
    }
     
    
    IEnumerator AddCost()
    {

        while (!gameManager.stageEnd)
        {
            if (cost < maxCost)
            {
                int currentCost;
                currentCost = cost + CostPlus(gameManager.redCastleLevel);

                if (currentCost >= maxCost)
                {
                    cost = maxCost;
                }
                else
                {
                    cost = currentCost;
                }

            }

            yield return new WaitForSeconds(1.5f);
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
        return plusCost;
    }


    IEnumerator CoolTime(float cooltime)
    {
        float maxCoolTime = cooltime;
        while (cooltime > 0f)
        {
            cooltime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }

    }

}
