using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlueCost : Cost
{
    public Text populationText;

    protected override void Start()
    {
        populationText.text = "" + castleInfo.populationLevel * 10;
        base.Start();
    }
}
