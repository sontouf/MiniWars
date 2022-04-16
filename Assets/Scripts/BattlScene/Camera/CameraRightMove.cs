using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRightMove : MonoBehaviour
{
    public GameObject mainCamera;
    public float speed;
    bool right, left;
    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
    }


    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            if (mainCamera.transform.position.x < 11)
                mainCamera.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void RightDown()
    {
        right = true;
    }
    public void RightUp()
    {
        right = false;
    }
}
