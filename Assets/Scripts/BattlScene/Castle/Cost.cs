using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cost : MonoBehaviour
{
    public int cost;
    public int plusCost;
    public int maxCost;
    public GameManager gameManager;
    public CastleInfo castleInfo;
    public Text costText;
    protected virtual void Start()
    {
        maxCost = 10;
        cost = 0;
        castleInfo = GetComponent<CastleInfo>();
        StartCoroutine("AddCost");
    }

    protected virtual IEnumerator AddCost()
    {

        while (!gameManager.stageEnd)
        {
            if (cost < maxCost)
            {
                int currentCost;
                currentCost = cost + CostPlus(castleInfo.castleLevel);

                if (currentCost >= maxCost)
                {
                    cost = maxCost;
                }
                else
                {
                    cost = currentCost;
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
                costText.text = "" + maxCost;
                break;
            case 2:
                plusCost = 2;
                maxCost = 20;
                costText.text = "" + maxCost;
                break;
            case 3:
                plusCost = 4;
                maxCost = 40;
                costText.text = "" + maxCost;
                break;
            case 4:
                plusCost = 6;
                maxCost = 60;
                costText.text = "" + maxCost;
                break;
            case 5:
                plusCost = 10;
                maxCost = 100;
                costText.text = "" + maxCost;
                break;
            case 6:
                plusCost = 14;
                maxCost = 160;
                costText.text = "" + maxCost;
                break;
            case 7:
                plusCost = 18;
                maxCost = 260;
                costText.text = "" + maxCost;
                break;
            case 8:
                plusCost = 24;
                maxCost = 410;
                costText.text = "" + maxCost;
                break;
            case 9:
                plusCost = 30;
                maxCost = 680;
                costText.text = "" + maxCost;
                break;

        }
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
