using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePosition : MonoBehaviour
{
    public GameObject target;
    public GameObject blueCastle;
    public GameObject canvasObject;
    UnitInfo unitInfo;
    float bluePath;
    float scaleX;
    // Update is called once per frame

    private void Start()
    {
        blueCastle = GameObject.Find("BlueCastle");
        canvasObject = GameObject.Find("SettingCanvas");
        scaleX = canvasObject.GetComponent<RectTransform>().localScale.x;
        bluePath = ResultY(blueCastle.GetComponent<BlueCastleInfo>().path);
        GetComponent<RectTransform>().position = new Vector3(40, 17, 0) * canvasObject.GetComponent<RectTransform>().localScale.x;
        unitInfo = target.GetComponent<UnitInfo>();
    }

    void Update()
    {
        if (!unitInfo.isDead)
            GetComponent<RectTransform>().position = CalculatePos(target.transform.position.x);
        //ResultY(master.GetComponent<GameManager>().bluePath), 0));
        else
            Destroy(gameObject);
    }

    public Vector3 CalculatePos(float targetPosX)
    {
        float valueX = 40 + ((float)(targetPosX - (-18)) * 90 / 36f);
        Vector3 resultPos = new Vector3(valueX, bluePath, 0) * scaleX;
        return resultPos;
    }

    public float ResultY(int y)
    {
        float result = 0;
        if (y == 2)
        {
            result =  23.5f;
        }
        else if (y == 0)
        {
            result =  15.7f;        
        }
        else if (y == -2)
        {
            result =  8;
        }
        return result;
    }
}
