using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCastleInfo : CastleInfo
{
    public void Start()
    {

    }
    public void topPath()
    {
        path = 2;
    }
    public void middlePath()
    {
        path = 0;
    }
    public void bottomPath()
    {
        path = -2;
    }

    float BluePathY(int bluePath)
    {
        float bluePathY = 0;
        if (bluePath == 2)
        {
            bluePathY = 23.5f;
        }
        else if (bluePath == 0)
        {
            bluePathY = 15.7f;

        }
        else if (bluePath == -2)
        {
            bluePathY = 8;
        }
        return bluePathY;
    }


}
