using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameManager gameManager;

    //-------------------------
    const string blueSwardPrefabPath = "Prefabs/BlueUnit/BlueSward";
    const string blueArcherPrefabPath = "Prefabs/BlueUnit/BlueArcher";
    string[] unitPrefabPath = new string[] { blueSwardPrefabPath, blueArcherPrefabPath };
    

    public void Button(MyType.UnitType unitType)
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber && gameManager.blueCost.cost >= MyType.UnitCost[(int)unitType])
        {
            //Debug.Log("int ?? " + (int)unitType);
            GameObject target = Instantiate(Resources.Load(unitPrefabPath[(int)unitType]) as GameObject, new Vector3(-18, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
            gameManager.blueCost.cost -= MyType.UnitCost[(int)unitType];
            target.GetComponent<UnitInfo>().positionObject = gameManager.CreateUnitPosition(target);
        }
    }
}
