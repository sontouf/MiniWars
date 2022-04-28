using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUnitButton : MonoBehaviour
{
    // PRIVATE FILDE
    int firstEmptyUnitIndex = 0;
    int nowUnitIndex = 0;

    // PUBLIC FILDE
    public UnitBox unitBox; // unitbox object를 관리하는 클래스.
    public void PlayerUnitButton() // 출전시키고자 하는 유닛을 선택하게 해준다.
    {
        // 빈공간이 있는지 확인하고 빈공간이 있다면 해당 공간의 유닛sprite와 유닛Id를 변경해준다.
        firstEmptyUnitIndex = CheckEmpty();
        if (firstEmptyUnitIndex == -1)
        {
            Debug.Log("not found Empty!");
            return;
        }
        if (GetComponent<Image>().sprite != unitBox.lockSprite && GetComponent<Image>().sprite != unitBox.empty && UnitBox.selectedUnitNumber < PlayerData.unlockUnitNumber)
        {
            unitBox.selectedUnits[firstEmptyUnitIndex].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            UnitBox.selectedUnitIds[firstEmptyUnitIndex] = unitBox.pageUnitIds[gameObject];
            UnitBox.selectedUnitNumber++;
        }
    }
    public void SelectedUnitButton() // 출전시키고자 한 유닛을 취소하게 해준다.
    {
        // 출전을 취소하고자 하는 유닛을 체크하고 유닛이 있다면 해당 공간의 유닛sprite와 유닛 Id를 초기화 시킨다.
        nowUnitIndex = CheckObject();
        if (nowUnitIndex == -1)
        {
            Debug.Log("full Unit!");
            return;
        }
        if (GetComponent<Image>().sprite != unitBox.lockSprite && GetComponent<Image>().sprite != unitBox.empty && UnitBox.selectedUnitNumber > 0)
        {
            GetComponent<Image>().sprite = unitBox.empty;
            UnitBox.selectedUnitIds[nowUnitIndex] = 0;
            UnitBox.selectedUnitNumber--;
        }
    }

    //-------sub function-----------
    //-------------위에 함수를 보조해준다.
    int CheckEmpty() // empty에 해당하는 첫 위치를 찾기.
    {
        int i = 0;
        for (; i < 8; i++)
        {
            if (unitBox.selectedUnits[i].GetComponent<Image>().sprite == unitBox.empty)
            {
                return i;
            }
        }
        return -1;
    }

    int CheckObject() // 선택한 버튼이 유닛이 저장되어있는 버튼이면 현재 위치를 반환한다.
    {
        int i = 0;
        for (; i < 8; i++)
        {
            if (unitBox.selectedUnits[i] == gameObject)
            {
                return i;
            }
        }
        return -1;
    }
}
