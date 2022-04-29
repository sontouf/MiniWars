using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCost : Cost
{
    public float waitForSecond;

    protected override void Start()
    {
        base.Start();
        waitForSecond = 1f;
    }

    protected override IEnumerator AddCost()
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

            yield return new WaitForSeconds(waitForSecond);
        }
    }
}
