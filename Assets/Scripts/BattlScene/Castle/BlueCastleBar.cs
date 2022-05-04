using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlueCastleBar : MonoBehaviour
{
    public int maxHp;
    static public int curHp;


    public float ratio;
    public Text costText;
    public Text costShadowText;
    RectTransform rectTransform;
    public Vector2 need;
    public float width;
    public float height;

    public BattleManager battleManager;

    //Vector2 result;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("Master").GetComponent<BattleManager>();
        maxHp = 1000;
        curHp = maxHp;
        rectTransform = GetComponent<RectTransform>();
        need = rectTransform.sizeDelta;
        width = need.x;
        height = need.y;
    }

    // Update is called once per frame
    void Update()
    {

        ratio = (float)curHp / (float)maxHp;
        width = ratio * need.x;
        rectTransform.sizeDelta = new Vector2(width, height);
        costText.text = "" + curHp;
        costShadowText.text = "" + curHp;


        if (curHp <= 0)
        {
            battleManager.win = false;
            battleManager.stageEnd = true;
        }
    }
}
