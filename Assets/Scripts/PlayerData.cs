using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static public int clearStageNumber; // 플레이어가 몇탄까지 깼는지 담는 정보.
    //public int coin;
    //public int upGradeCoin;

    // 초기화를 해주었다.
    static public List<int> unitObjectList = new List<int>() { 10000, 10100, 10200, 10500}; // 플레이어가 가지고 있는 유닛정보들.
    static public int unlockUnitNumber = 4; // battle 시 사용할수있는 유닛의 수.
    //static public List<GameObject> itemList = new List<GameObject>();
    //public GameObject hero;


    // Start is called before the first frame update
    void Start() // batlle 준비, 유닛 선택창에 들어왔을때 필요한 플레이어 정보이다. 플레이어가 갖고 있는 유닛 정보들.
        // 현재는 start문 내에 작성을 했지만 나중에 start문 없어도 됨. 
    {
        //unlockUnitNumber = 7;
        //Debug.Log(unitObjectList.Count);
        //unitObjectList.Clear();
        /*        unitObjectList.Add(10000);
                unitObjectList.Add(10100);
                unitObjectList.Add(10200);
                unitObjectList.Add(10500);*/
/*        unitObjectList[0] = 10000;
        unitObjectList[1] = 10100;
        unitObjectList[2] = 10200;
        unitObjectList[3] = 10500;*/

    }


    // 종족 . 유닛 . 레벨

    // 1 00 00 
    // sward  10000
    // archer 10100
    // armouredSward 10200
    // art
    // patrol 10500
}
