using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightShoulderGraph : Graph
{
    float min;
    float max;

    public RightShoulderGraph(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public RightShoulderGraph()
    { }

    public override float CheckIfContained(float value)//, float min, float mid, float max)
    {
        if (value > max)
        {
            return 1.0f;
        }
        else if (value <= min)
        {
            return 0.0f;
        }
            return((value - min) / (max - min));
    }
}
