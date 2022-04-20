using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpriteManager : MonoBehaviour
{

    const string playerAndEnemyUnitSpritesOnPath = "Sprites/Setting/UnitLevel/All1t";
    const string playerUnitSpritesOffPath = "Sprites/Setting/UnitLevel/AllGrayScale";

    public Sprite[] playerAndEnemyUnitSpritesOn;
    public Sprite[] playerUnitSpritesOff;



    // playerUnit List ON


    public List<Sprite> blueSwardList = new List<Sprite>();
    public List<Sprite> blueArcherList = new List<Sprite>();
    public List<Sprite> blueArmouredSwardList = new List<Sprite>();
    public List<Sprite> bluePatrolList = new List<Sprite>();

    // playerUnit OFF;

    public List<Sprite> blueSwardOffList = new List<Sprite>();
    public List<Sprite> blueArcherOffList = new List<Sprite>();
    public List<Sprite> blueArmouredSwardOffList = new List<Sprite>();
    public List<Sprite> bluePatrolOffList = new List<Sprite>();


    // enemyUnit

    public List<Sprite> redSwardList = new List<Sprite>();
    public List<Sprite> redArcherList = new List<Sprite>();
    public List<Sprite> redArmouredSwardList = new List<Sprite>();
    public List<Sprite> redPatrolList = new List<Sprite>();



    private void Start()
    {

        playerAndEnemyUnitSpritesOn = Resources.LoadAll<Sprite>(playerAndEnemyUnitSpritesOnPath);
        playerUnitSpritesOff = Resources.LoadAll<Sprite>(playerUnitSpritesOffPath);
        for (int i = 0; i < playerAndEnemyUnitSpritesOn.Length; i++)
        {
            if (i < 81)
            {
                if (i % 9 == 0)
                {
                    blueSwardList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 1)
                {
                    blueArcherList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 2)
                {
                    blueArmouredSwardList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 5)
                {
                    bluePatrolList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
            }
            else
            {
                if (i % 9 == 0)
                {
                    redSwardList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 1)
                {
                    redArcherList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 2)
                {
                    redArmouredSwardList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
                else if (i % 9 == 5)
                {
                    redPatrolList.Add(playerAndEnemyUnitSpritesOn[i]);
                }
            }

        }

        for (int i = 0; i < playerUnitSpritesOff.Length; i++)
        {
            if (i < 81)
            {
                if (i % 9 == 0)
                {
                    blueSwardOffList.Add(playerUnitSpritesOff[i]);
                }
                else if (i % 9 == 1)
                {
                    blueArcherOffList.Add(playerUnitSpritesOff[i]);
                }
                else if (i % 9 == 2)
                {
                    blueArmouredSwardOffList.Add(playerUnitSpritesOff[i]);
                }
                else if (i % 9 == 5)
                {
                    bluePatrolOffList.Add(playerUnitSpritesOff[i]);
                }
            }


        }

    }
}
