using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleInfo : MonoBehaviour
{
    public GameManager gameManager;

    public int path = 0;
    public int populationLevel = 1;
    public Cost cost;
    public int castleLevel = 1;
    public int curPopulation = 0;
    public int maxPopulation = 10;

    protected virtual void Start()
    {
        gameManager = GameObject.Find("Master").GetComponent<GameManager>();
        if (gameObject.layer == 8)
            cost = GetComponent<BlueCost>();
        else
            cost = GetComponent<RedCost>();
    }

    public void UpgradeCastleLevel()
    {
        if (!gameManager.stageEnd && cost.curCost == cost.maxCost)
        {
            cost.curCost -= cost.maxCost;
            castleLevel += 1;
        }
    }

    protected virtual void UpgradePopulationLevel()
    {
        if (!gameManager.stageEnd && cost.curCost >= populationLevel * 10)
        {
            cost.curCost -= populationLevel * 10;
            populationLevel += 1;
            if (gameObject.layer == 8)
            //cost.populationText.text = "" + populationLevel * 10;
            maxPopulation = populationLevel * 10;
        }
    }
}
