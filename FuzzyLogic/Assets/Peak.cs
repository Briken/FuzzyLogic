using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Peak : Graph
{
    float min;
    float mid;
    float max;

    public Peak(float min, float mid, float max)
    {
        this.min = min;
        this.mid = mid;
        this.max = max;
    }

    public Peak()
    { }

    public override float CheckIfContained(float value)//, 
    {
        if (value < min || value > max)
        {
            return 0.0f;
        }

        if (value < mid)
        {
            return (value - min) / (mid - min);
        }

        return 1 - ((value - mid) / (max - mid));
    }
}