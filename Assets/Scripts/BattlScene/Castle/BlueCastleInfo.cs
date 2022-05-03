using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCastleInfo : CastleInfo
{
    public Text requiredPopulationUpText;
    public Text populationText;
    public Text populationShadowText;
    public GameObject child;
    public GameObject bluePosition;

    protected override void Start()
    {
        base.Start();
        requiredPopulationUpText.text = "" + populationLevel * 10;
        bluePosition = GameObject.Find("Prefabs/BlueUnitPosition");
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

    public GameObject CreateUnitPosition(GameObject target)
    {
        // MiniMap의 유닛 위치를 생성해주는 함수이다.인자로 위치표시가 필요한 target이 들어온다.
        child = Instantiate(bluePosition);
        child.transform.SetParent(gameManager.canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(40, BluePathY(path), 0) * gameManager.canvasObject.GetComponent<RectTransform>().localScale.x;
        // Debug.Log("a : " + child.GetComponent<RectTransform>().position);
        child.GetComponent<BluePosition>().target = target;
        return child;
    }



    protected override void UpgradePopulationLevel()
    {
        base.UpgradePopulationLevel();
        requiredPopulationUpText.text = "" + populationLevel * 10;
    }

}
