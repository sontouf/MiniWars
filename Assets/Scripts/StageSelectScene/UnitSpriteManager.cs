using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpriteManager : MonoBehaviour
{

    const string playerAndEnemyUnitSpritesOnPath = "Sprites/Setting/UnitLevel/All1t";
    const string playerUnitSpritesOffPath = "Sprites/Setting/UnitLevel/AllGrayScale";

    public Sprite[] playerAndEnemyUnitSpritesOn; // 활성화 sprite 를 담는 곳
    public Sprite[] playerUnitSpritesOff; // 비활성화 sprite 를 담는 곳



    // playerUnit List ON


    public Dictionary<int, List<Sprite>> unitOnList = new Dictionary<int, List<Sprite>>(); // player Unit 활성화 담는 곳
    public Dictionary<int, List<Sprite>> unitOffList = new Dictionary<int, List<Sprite>>(); // player Unit 비활성화 담는 곳
    public Dictionary<int, List<Sprite>> redUnitList = new Dictionary<int, List<Sprite>>(); // enemy Unit 활성화 담는곳 - 스테이지 설명Scene에서 사용됨.

    private void Start()
    {
        // sprite 연결.
        playerAndEnemyUnitSpritesOn = Resources.LoadAll<Sprite>(playerAndEnemyUnitSpritesOnPath); 
        playerUnitSpritesOff = Resources.LoadAll<Sprite>(playerUnitSpritesOffPath);

        // dictionary에 사용될 list 생성.
        for (int i = 0; i < 9; i++)
        {
            unitOnList.Add(i, new List<Sprite>());
            unitOffList.Add(i, new List<Sprite>());
            redUnitList.Add(i, new List<Sprite>());
        }

        // 각각의 list에 sprite 연결.
        for (int i = 0; i < playerAndEnemyUnitSpritesOn.Length; i++)
        {
            if (i < 81)
                    unitOnList[i % 9].Add(playerAndEnemyUnitSpritesOn[i]);
            else
                redUnitList[i % 9].Add(playerAndEnemyUnitSpritesOn[i]);

        }

        for (int i = 0; i < playerUnitSpritesOff.Length; i++)
        {
            if (i < 81)
                unitOffList[i % 9].Add(playerUnitSpritesOff[i]);
        }

    }
}
