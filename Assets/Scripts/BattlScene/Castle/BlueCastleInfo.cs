using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCastleInfo : CastleInfo
{
    public Text requiredPopulationUpText;
    public Text populationText;
    public Text populationShadowText;
    //public GameObject child;
    public GameObject bluePosition;

    protected override void Start()
    {
        base.Start();
        requiredPopulationUpText.text = "" + populationLevel * 10;
        bluePosition = Resources.Load("Prefabs/BlueUnitPosition") as GameObject;
    }
    void Update()
    {
        populationShadowText.text = curPopulation + "/" + maxPopulation;
        populationText.text = curPopulation + "/" + maxPopulation;

    }
    public void topPath()
    {
        path = 2;
    }
    public void middlePath()
    {
        path = 0;
    }
    public void bottomPath()
    {
        path = -2;
    }



    protected override void UpgradePopulationLevel()
    {
        base.UpgradePopulationLevel();
        requiredPopulationUpText.text = "" + populationLevel * 10;
    }

}
