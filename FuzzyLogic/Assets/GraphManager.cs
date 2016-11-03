using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour {

    Graph master;
    RightShoulderGraph good;
    Peak grey;
    LeftShoulderGraph evil;

    public InputField xVal;
    float value;

	// Use this for initialization
	void Start ()
    {
        master = new Graph();
        good = new RightShoulderGraph(50, 75);
        grey = new Peak(25, 50, 75);
        evil = new LeftShoulderGraph(25, 50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fuzzify()
    {
        value = float.Parse(xVal.text);
        Debug.Log("This number is held within the good set to " + good.CheckIfContained(value)*100 + " degree");
        Debug.Log("This number is held within the grey set to " + grey.CheckIfContained(value)*100 + " degree");
        Debug.Log("This number is held within the evil set to " + evil.CheckIfContained(value)*100 + " degree");
    }
}
