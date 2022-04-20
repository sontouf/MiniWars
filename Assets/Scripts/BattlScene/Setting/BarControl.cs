using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{

    public BlueCost blueCost;
    public float ratio;
    public Text costText;
    public RedCost redCost;
    public Text redCostText;
    public Text costShadowText;
    RectTransform rectTransform;
    public Vector2 need;
    public float width;
    public float height;

    //Vector2 result;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        need = rectTransform.sizeDelta;
        width = need.x;
        height = need.y;
    }

    // Update is called once per frame
    void Update()
    {

        ratio = (float)blueCost.cost / (float)blueCost.maxCost;
        width = ratio * need.x;
        rectTransform.sizeDelta = new Vector2(width, height);
        costText.text = "" + blueCost.cost + "/" + blueCost.maxCost;
        redCostText.text = "" + redCost.cost + "/" + redCost.maxCost;
        costShadowText.text = "" + blueCost.cost + "/" + blueCost.maxCost;

    }
}
