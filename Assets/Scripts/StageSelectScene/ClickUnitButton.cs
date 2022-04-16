using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUnitButton : MonoBehaviour
{
    public UnitBox unitBox;
    public int firstEmptyUnitIndex = 0;
    public int nowUnitIndex = 0;
    public void PlayerUnitButton()
    {
        CheckEmpty();
        if (GetComponent<Image>().sprite != unitBox.lockSprite && GetComponent<Image>().sprite != unitBox.empty && UnitBox.selectedUnitNumber < PlayerData.unlockUnitNumber)
        {
            unitBox.selectedUnits[firstEmptyUnitIndex].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            UnitBox.selectedUnitIds[firstEmptyUnitIndex] = unitBox.pageUnitIds[gameObject];
            UnitBox.selectedUnitNumber++;
        }
       
    }
    public void SelectedUnitButton()
    {
        CheckObject();
        if (GetComponent<Image>().sprite != unitBox.lockSprite && GetComponent<Image>().sprite != unitBox.empty && UnitBox.selectedUnitNumber > 0)
        {
            GetComponent<Image>().sprite = unitBox.empty;
            UnitBox.selectedUnitIds[nowUnitIndex] = 0;
            UnitBox.selectedUnitNumber--;
        }

    }

    public void CheckEmpty()
    {
        for (int i = 0; i < 8; i++)
        {
 
            if (unitBox.selectedUnits[i].GetComponent<Image>().sprite == unitBox.empty)
            {
                firstEmptyUnitIndex = i;
                break;
            }
        }
    }

    public void CheckObject()
    {
        for ( int i = 0; i < 8; i++)
        {
            if (unitBox.selectedUnits[i] == gameObject)
            {
                nowUnitIndex = i;
                break;
            }
        }
    }
}
