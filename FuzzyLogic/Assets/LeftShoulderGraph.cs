using UnityEngine;
using System.Collections;

public class LeftShoulderGraph : Graph
{
     public override float Evil(float x)
    {
        max = 50;
        min = 0;
        if (x <= 25)
        {
            y = 1;
        }
        else if (x < max && x > 25)
        {
            y = (x - 25.0f) / (max - 25);
        }
        else
        {
            y = 0;
        }
        return y;
    }     

}
