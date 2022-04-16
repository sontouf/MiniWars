using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    float frame;
    // Update is called once per frame
    void Update()
    {
        frame += 0.015f;
        float width = Mathf.Sin(frame) * 0.15f;
        transform.Translate(new Vector3(0, width, 0));
    }
}
