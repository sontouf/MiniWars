using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleBar : MonoBehaviour
{
    public int maxHp;
    public int curHp;


    float ratio;
    public Text costText;
    public Text costShadowText;
    RectTransform rectTransform;
    Vector2 need;
    float width;
    float height;

    public BattleManager battleManager;
    public GameObject castleBar;

    //Vector2 result;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("Master").GetComponent<BattleManager>();
        maxHp = 1000;
        curHp = maxHp;
        rectTransform = castleBar.GetComponent<RectTransform>();
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
