using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCount : MonoBehaviour
{
    public GameManager gameManager;
    public Text unitCountText;
    public Text unitCountShadowText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        unitCountText.text = "" + GameManager.blueCurUnitNumber + "/" + gameManager.blueMaxUnitNumber;
        unitCountShadowText.text = "" + GameManager.blueCurUnitNumber + "/" + gameManager.blueMaxUnitNumber;
    }
}
