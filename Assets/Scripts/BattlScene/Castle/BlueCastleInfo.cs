using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCastleInfo : CastleInfo
{
    public Text requiredPopulationUpText;
    public Text populationText;
    public Text populationShadowText;

    protected override void Start()
    {
        base.Start();
        requiredPopulationUpText.text = "" + populationLevel * 10;
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

    float BluePathY(int bluePath)
    {
        float bluePathY = 0;
        if (bluePath == 2)
        {
            bluePathY = 23.5f;
        }
        else if (bluePath == 0)
        {
            bluePathY = 15.7f;

        }
        else if (bluePath == -2)
        {
            bluePathY = 8;
        }
        return bluePathY;
    }


}
