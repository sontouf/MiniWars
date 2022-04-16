using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static public int clearStageNumber;
    public int coin;
    public int upGradeCoin;
    static public List<int> unitObjectList = new List<int>(30);
    static public int unlockUnitNumber;
    static public List<GameObject> itemList = new List<GameObject>();
    public GameObject hero;


    // Start is called before the first frame update
    void Start()
    {
        unlockUnitNumber = 3;
        unitObjectList.Add(10000);
        unitObjectList.Add(10100);
        unitObjectList.Add(10200);

    }


    // 종족 . 유닛 . 레벨

    // 1 00 00 
    // sward  10000
    // archer 10100
    // armouredSward 10200
    // 
}
