using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUnitPosition : MonoBehaviour
{
    public GameObject target;
    public GameObject master;
    public GameObject canvasObject;
    public float redPath;
    float scaleX;
    // Update is called once per frame

    private void Start()
    {
        master = GameObject.Find("Master");
        canvasObject = GameObject.Find("SettingCanvas");
        scaleX = canvasObject.GetComponent<RectTransform>().localScale.x;
        // GetComponent<RectTransform>().position = Camera.main.ScreenToWorldPoint(new Vector3(134, 17, 0));
    }


    void Update()
    {

        GetComponent<RectTransform>().position = CalculatePos(target.transform.position.x);

    }

    public Vector3 CalculatePos(float targetPosX)
    {
        float valueX = 130 + ((float)(targetPosX - (18)) * 90 / 36f);
        Vector3 resultPos = new Vector3(valueX, redPath, 0) * scaleX;
        return resultPos;
    }

}
