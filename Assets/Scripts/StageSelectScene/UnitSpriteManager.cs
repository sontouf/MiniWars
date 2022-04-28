using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpriteManager : MonoBehaviour
{
    const string playerAndEnemyUnitSpritesOnPath = "Sprites/Setting/UnitLevel/All1t";
    const string playerUnitSpritesOffPath = "Sprites/Setting/UnitLevel/AllGrayScale";

    Sprite[] playerAndEnemyUnitSpritesOn; // 활성화 sprite 를 담는 곳
    Sprite[] playerUnitSpritesOff; // 비활성화 sprite 를 담는 곳



    // playerUnit Lists - sprite정보는 여기저기서 쓰이므로 public로 접근한정자를 정해주었다.
    static public Dictionary<int, List<Sprite>> unitOnList = new Dictionary<int, List<Sprite>>(); // player Unit 활성화 담는 곳
    static public Dictionary<int, List<Sprite>> unitOffList = new Dictionary<int, List<Sprite>>(); // player Unit 비활성화 담는 곳
    static public Dictionary<int, List<Sprite>> redUnitList = new Dictionary<int, List<Sprite>>(); // enemy Unit 활성화 담는곳 - 스테이지 설명Scene에서 사용됨.

    private void Start()
    {
        // sprite 연결. LoadAll 함수를 쓰면 저장되어 있는 만큼의 sprite정보가 들어오므로 배열 데이터에 저장해도된다.
        playerAndEnemyUnitSpritesOn = Resources.LoadAll<Sprite>(playerAndEnemyUnitSpritesOnPath); 
        playerUnitSpritesOff = Resources.LoadAll<Sprite>(playerUnitSpritesOffPath);

        // dictionary에 사용될 list 생성.
        for (int i = 0; i < 9; i++)
        {
            if (!unitOnList.ContainsKey(i))
                unitOnList.Add(i, new List<Sprite>());
            if (!unitOffList.ContainsKey(i))
                unitOffList.Add(i, new List<Sprite>());
            if (!redUnitList.ContainsKey(i))
                redUnitList.Add(i, new List<Sprite>());
        }

        // 각각의 list에 sprite 연결.
        for (int i = 0; i < playerAndEnemyUnitSpritesOn.Length; i++)
        {
            if (i < 81)
            {
                if (unitOnList[i % 9].Count != 9)
                    unitOnList[i % 9].Add(playerAndEnemyUnitSpritesOn[i]);
            }
            else
                if (redUnitList[i % 9].Count != 9)
                    redUnitList[i % 9].Add(playerAndEnemyUnitSpritesOn[i]);

        }

        for (int i = 0; i < playerUnitSpritesOff.Length; i++)
        {
            if (i < 81)
                unitOffList[i % 9].Add(playerUnitSpritesOff[i]);
        }

    }
}
