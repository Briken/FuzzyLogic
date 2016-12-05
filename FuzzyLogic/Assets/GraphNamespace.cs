namespace GraphNs
{
    public class RightShoulderGraph : Graph
    {
        float min;
        float max;
        float maxConfidence;

        public RightShoulderGraph(float min, float max, float yMax)
        {
            this.min = min;
            this.max = max;
            this.maxConfidence = yMax;
        }

        public RightShoulderGraph()
        { }

        public override float CheckIfContained(float value)//, float min, float mid, float max)
        {
            if (value > max)
            {
                return maxConfidence;
            }
            else if (value <= min)
            {
                return 0.0f;
            }
            return ((value - min) / (max - min));
        }
        public float GetMin()
        {
            return min;
        }
        public float GetMax()
        {
            return max;
        }
    }

    public class LeftShoulderGraph : Graph
    {
        float min;
        float max;
        float maxConfidence;

        public LeftShoulderGraph(float min, float max, float yMax)
        {
            this.min = min;
            this.max = max;
            this.maxConfidence = yMax;
        }

        public LeftShoulderGraph()
        { }

        public override float CheckIfContained(float value)//, float min, float max)
        {
            if (value < min)
            {
                return maxConfidence;
            }
            else if (value > max)
            {
                return 0;
            }

            return maxConfidence - ((value - min) / (max - min));
        }

        public float GetMin()
        {
            return min;
        }
        public float GetMax()
        {
            return max;
        }

    }
    public class Peak : Graph
    {
        float min;
        float mid;
        float max;
        float maxConfidence;

        public Peak(float min, float mid, float max, float yMax)
        {
            this.min = min;
            this.mid = mid;
            this.max = max;
            this.maxConfidence = yMax;
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

            return maxConfidence - ((value - mid) / (max - mid));
        }
        public float GetMin()
        {
            return min;
        }
        public float GetMax()
        {
            return max;
        }
        public float GetMid()
        {
            return mid;
        }
    }

    public class Trapezoid : Graph
    {
        float minLeft;
        float minRight;
        float maxLeft;
        float maxRight;
        float maxConfidence;

        public Trapezoid(float leftMin, float leftMax, float rightMin, float rightMax, float yMax)
        {
            this.minLeft = leftMin;
            this.minRight = rightMin;
            this.maxLeft = leftMax;
            this.maxRight = rightMax;

            this.maxConfidence = yMax;
        }
        public Trapezoid()
        {
        }
        public override float CheckIfContained(float value)//, 
        {
            if (value < minLeft || value > maxRight)
            {
                return 0.0f;
            }
            if (value > maxLeft && value < minRight)
            {
                return maxConfidence;
            }
            if (value < maxLeft)
            {
                return (value - minLeft) / (maxLeft - minLeft);
            }

            return maxConfidence - ((value - minRight) / (maxRight - minRight));
        }
        public float GetLMin()
        {
            return minLeft;
        }
        public float GetLMax()
        {
            return maxLeft;
        }
        public float GetRMin()
        {
            return minRight;
        }
        public float GetRMax()
        {
            return maxRight;
        }

    }

}
