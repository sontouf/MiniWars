using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameManager gameManager;
    public BlueCastleInfo blueCastleInfo;

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
            //target.GetComponent<UnitInfo>().positionObject = GameManager.CreateUnitPosition(target);
        }
    }
}
