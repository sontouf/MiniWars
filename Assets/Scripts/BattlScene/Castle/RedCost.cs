using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCost : Cost
{
    public float waitForSecond;

    protected override void Start()
    {
        requiredCostText = null;
        base.Start();
        waitForSecond = 1f;
    }

    protected override IEnumerator AddCost()
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

            yield return new WaitForSeconds(waitForSecond);
        }
    }
}
