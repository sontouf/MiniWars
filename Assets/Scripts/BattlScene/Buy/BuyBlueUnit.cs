using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBlueUnit : MonoBehaviour // 얘는 아직 안 쓰이는 스크립트
{
    int level;
    bool isWizard;

    GameManager gameManager;

    public GameObject bSwardPrefab;
    public GameObject bArcherPrefab;
    public GameObject bArmouredSwardPrefab;
    public GameObject bCavalryPrefab;
    public GameObject bPatrolPrefab;
    public GameObject bRoyalGuardPrefab;
    public GameObject bShieldPrefab;
    public GameObject bSpearManPrefab;

    public void SwardButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bSwardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ArcherButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bArcherPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ShieldButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bShieldPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ArmouredSwardButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bArmouredSwardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void PatrolButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bPatrolPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void SpearManButton()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bSpearManPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void Cavalry()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bCavalryPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void RoyalGuard()
    {
        if (!gameManager.stageEnd && GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bRoyalGuardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
}
