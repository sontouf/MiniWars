using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public RedCost redCost;
    int pattern;

    public GameObject swardPrefab;
    public GameObject archerPrefab;
    public GameObject armouredSwardPrefab;
    public GameObject cavalryPrefab;
    public GameObject patrolPrefab;
    public GameObject royalGuardPrefab;
    public GameObject shieldPrefab;
    public GameObject spearManPrefab;
    public int redPath;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        pattern = 0;
        StartCoroutine("RedAI");
    }

    IEnumerator RedAI()
    {
        while (true)
        {
            if (pattern == 0)
            {
                if (redCost.cost >= 8 && GameManager.redCurUnitNumber < gameManager.redMaxUnitNumber)
                {
                    redPath = Random.Range(-1, 2);
                    int rand = Random.Range(0, 2);
                    switch (rand)
                    {
                        case 0:
                            Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                            redCost.cost -= 3;
                            GameManager.redCurUnitNumber += 1;
                            break;
                        case 1:
                            Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                            redCost.cost -= 5;
                            GameManager.redCurUnitNumber += 1;
                            break;
                    }
                    if (redCost.cost >= 5 && GameManager.redCurUnitNumber < gameManager.redMaxUnitNumber)
                    {
                        redPath = Random.Range(-1, 2);
                        int nextRand = Random.Range(0, 3);
                        switch (nextRand)
                        {
                            case 0:
                                Instantiate(swardPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                                redCost.cost -= 3;
                                GameManager.redCurUnitNumber += 1;
                                break;
                            case 1:
                                Instantiate(archerPrefab, new Vector3(18, redPath * 2, 0), Quaternion.identity);
                                redCost.cost -= 5;
                                GameManager.redCurUnitNumber += 1;
                                break;
                            case 2:
                                break;
                        }
                    }
                    
                }

            }
            yield return new WaitForSeconds(1.5f);
        }

    }

}
