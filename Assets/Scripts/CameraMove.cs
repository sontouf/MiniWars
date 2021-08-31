﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
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
            if (mainCamera.transform.position.x < 8)
                mainCamera.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (left)
        {
            if (mainCamera.transform.position.x > -8)
                mainCamera.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void RightUp()
    {
        right = false;
    }
    public void RightDown()
    {
        right = true;
    }
    public void LeftUp()
    {
        left = false;
    }
    public void LeftDown()
    {
        left = true;
    }


}
