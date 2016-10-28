using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour {

    protected float max;
    protected float min;
    protected float y;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual float Good(float x)
    {
        return y;
    }

    public virtual float Evil(float x)
    {
        return y;
    }

    public virtual float Grey(float x)
    {
        return y;
    }
}
