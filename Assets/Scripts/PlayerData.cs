using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static public int clearStageNumber = 0; // 플레이어가 몇탄까지 깼는지 담는 정보.
    //public int coin;
    //public int upGradeCoin;

    // 초기화를 해주었다.
    static public List<int> unitObjectList = new List<int>() { 10000, 10100, 10200, 10500}; // 플레이어가 가지고 있는 유닛정보들.
    static public int unlockUnitNumber = 4; // battle 시 사용할수있는 유닛의 수.
    //static public List<GameObject> itemList = new List<GameObject>();
    //public GameObject hero;


    // 종족 . 유닛 . 레벨

    // 1 00 00 
    // sward  10000
    // archer 10100
    // armouredSward 10200
    // art
    // patrol 10500
}
