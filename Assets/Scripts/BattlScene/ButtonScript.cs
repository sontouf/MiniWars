using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public BattleManager battleManager;
    public BlueCastleInfo blueCastleInfo;
    //-------------------------
/*    const string blueSwardPrefabPath = "Prefabs/BlueUnit/BlueSward";
    const string blueArcherPrefabPath = "Prefabs/BlueUnit/BlueArcher";*/
    string[] unitPrefabPath = new string[] 
    { "Prefabs/BlueUnit/BlueSward", "Prefabs/BlueUnit/BlueArcher", "Prefabs/BlueUnit/BlueArmouredSward",
    "Prefabs/BlueUnit/BlueArtilleryMan", "Prefabs/BlueUnit/BlueCavalry", "Prefabs/BlueUnit/BluePatrol",
    "Prefabs/BlueUnit/BlueRoyalGuard", "Prefabs/BlueUnit/BlueShield", "Prefabs/BlueUnit/BlueSpearMan"};

    private void Start()
    {
        battleManager = GameObject.Find("Master").GetComponent<BattleManager>();
    }

    public void Button(MyType.UnitType unitType)
    {
        if (!battleManager.stageEnd && blueCastleInfo.curPopulation < blueCastleInfo.maxPopulation && blueCastleInfo.cost.curCost >= MyType.UnitCost[(int)unitType])
        {
            //Debug.Log("int ?? " + (int)unitType);
            GameObject target = Instantiate(Resources.Load(unitPrefabPath[(int)unitType]) as GameObject, new Vector3(-18, blueCastleInfo.path, 0), Quaternion.identity);
            blueCastleInfo.curPopulation += 1;
            blueCastleInfo.cost.curCost -= MyType.UnitCost[(int)unitType];
            CreateUnitPosition(target, target.GetComponent<UnitInfo>().positionObject);
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

    void CreateUnitPosition(GameObject target, GameObject positionObject)
    {
        // MiniMap의 유닛 위치를 생성해주는 함수이다.인자로 위치표시가 필요한 target이 들어온다.
        positionObject = Instantiate(blueCastleInfo.bluePosition);
        positionObject.transform.SetParent(battleManager.canvasObject.transform);

        positionObject.transform.localScale = new Vector3(1, 1, 1);
        positionObject.GetComponent<RectTransform>().position = new Vector3(40, BluePathY(blueCastleInfo.path), 0) * battleManager.canvasObject.GetComponent<RectTransform>().localScale.x;
        // Debug.Log("a : " + child.GetComponent<RectTransform>().position);
        positionObject.AddComponent<BluePosition>();
        positionObject.GetComponent<BluePosition>().target = target;
    }
}
