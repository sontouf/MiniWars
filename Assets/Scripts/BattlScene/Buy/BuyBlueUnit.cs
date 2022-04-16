using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBlueUnit : MonoBehaviour
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
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bSwardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ArcherButton()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bArcherPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ShieldButton()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bShieldPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void ArmouredSwardButton()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bArmouredSwardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void PatrolButton()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bPatrolPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void SpearManButton()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bSpearManPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void Cavalry()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bCavalryPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
    public void RoyalGuard()
    {
        if (GameManager.blueCurUnitNumber < gameManager.blueMaxUnitNumber)
        {
            Instantiate(bRoyalGuardPrefab, new Vector3(-15, gameManager.bluePath, 0), Quaternion.identity);
            GameManager.blueCurUnitNumber += 1;
        }
    }
}
