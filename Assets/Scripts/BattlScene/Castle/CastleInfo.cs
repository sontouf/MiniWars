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

    private void Start()
    {
        gameManager = GameObject.Find("Master").GetComponent<GameManager>();
        cost = GetComponent<Cost>();
    }

    public void UpgradeCastleLevel()
    {
        if (!gameManager.stageEnd && cost.cost == cost.maxCost)
        {
            cost.cost -= cost.maxCost;
            castleLevel += 1;
        }
    }

    public void UpgradePopulationLevel()
    {
        if (!gameManager.stageEnd && cost.cost >= populationLevel * 10)
        {
            cost.cost -= populationLevel * 10;
            populationLevel += 1;
            maxPopulation = populationLevel * 10;
        }
    }
}
