using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Vector3 GetTeamValue(Vector3 blue, Vector3 red)
    {
        if (gameObject.layer == 8)
        {
            return blue;
        }
        else
        {
            return red;
        }
    }

    public LayerMask GetTeamValue(LayerMask blue, LayerMask red)
    {
        if (gameObject.layer == 8)
        {
            return blue;
        }
        else
        {
            return red;
        }
    }

}
