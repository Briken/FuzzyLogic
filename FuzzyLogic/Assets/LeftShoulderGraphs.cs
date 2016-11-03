using UnityEngine;
using System.Collections;

public class LeftShoulderGraph : Graph
{
    float min;
    float max;

    public LeftShoulderGraph(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public LeftShoulderGraph()
    { }

    public override float CheckIfContained(float value)//, float min, float max)
    {
        if (value < min)
        {
            return 1;
        }
        else if (value > max)
        {
            return 0;
        }

        return 1 - ((value - min) / (max - min));
    }
}
