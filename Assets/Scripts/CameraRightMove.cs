using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRightMove : MonoBehaviour
{
    public Camera mainCamera;
    float speed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
/*        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);*/
        speed = 2;
        pos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    public void OnPointerDownDelegate(PointerEventData data)
    {
        Debug.Log("a");
        pos.x += speed * Time.deltaTime;
        mainCamera.transform.position = pos;
    }*/

    public void CameraMove()
    {
        pos.x += speed * Time.deltaTime;
        mainCamera.transform.position = pos;
    }
}
