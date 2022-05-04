using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameManager gameManager;
    public BlueCastleInfo blueCastleInfo;
    GameObject child;
    //-------------------------
/*    const string blueSwardPrefabPath = "Prefabs/BlueUnit/BlueSward";
    const string blueArcherPrefabPath = "Prefabs/BlueUnit/BlueArcher";*/
    string[] unitPrefabPath = new string[] 
    { "Prefabs/BlueUnit/BlueSward", "Prefabs/BlueUnit/BlueArcher", "Prefabs/BlueUnit/BlueArmouredSward",
    "Prefabs/BlueUnit/BlueArtilleryMan", "Prefabs/BlueUnit/BlueCavalry", "Prefabs/BlueUnit/BluePatrol",
    "Prefabs/BlueUnit/BlueRoyalGuard", "Prefabs/BlueUnit/BlueShield", "Prefabs/BlueUnit/BlueSpearMan"};
    

    public void Button(MyType.UnitType unitType)
    {
        if (!gameManager.stageEnd && blueCastleInfo.curPopulation < blueCastleInfo.maxPopulation && blueCastleInfo.cost.curCost >= MyType.UnitCost[(int)unitType])
        {
            //Debug.Log("int ?? " + (int)unitType);
            GameObject target = Instantiate(Resources.Load(unitPrefabPath[(int)unitType]) as GameObject, new Vector3(-18, blueCastleInfo.path, 0), Quaternion.identity);
            blueCastleInfo.curPopulation += 1;
            blueCastleInfo.cost.curCost -= MyType.UnitCost[(int)unitType];
            target.GetComponent<UnitInfo>().positionObject = CreateUnitPosition(target);
        }
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
        child = Instantiate(blueCastleInfo.bluePosition);
        child.transform.SetParent(gameManager.canvasObject.transform);

        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<RectTransform>().position = new Vector3(40, BluePathY(blueCastleInfo.path), 0) * gameManager.canvasObject.GetComponent<RectTransform>().localScale.x;
        // Debug.Log("a : " + child.GetComponent<RectTransform>().position);
        child.GetComponent<BluePosition>().target = target;
        return child;
    }
}
