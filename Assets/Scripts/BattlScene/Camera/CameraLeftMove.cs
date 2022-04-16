using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraLeftMove : MonoBehaviour
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
        if (left)
        {
            if (mainCamera.transform.position.x > -11)
                mainCamera.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void LeftDown()
    {
        left = true;
    }
    public void LeftUp()
    {
        left = false;
    }
}
