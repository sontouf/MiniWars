using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraLeftMove : MonoBehaviour
{
    public Camera mainCamera;
    float speed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        speed = -2;
        pos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointDown(PointerEventData data)
    {
        pos.x += speed * Time.deltaTime;
        mainCamera.transform.position = pos;
    }
}
