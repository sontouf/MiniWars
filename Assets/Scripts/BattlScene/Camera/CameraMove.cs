using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject mainCamera;
    private float Speed = 0.25f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                Vector3 pos = mainCamera.transform.position + movePos;
                if ((pos.x > -11 || pos.x < 11) && pos.y == 0)
                {
                    mainCamera.transform.Translate(movePos);
                }
                prePos = touch.position - touch.deltaPosition;
            }
        }
    }

}
