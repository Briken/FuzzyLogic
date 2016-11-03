using UnityEngine;
using System.Collections;

public class Fuzzification : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Evil(float crisp)
    {
    }
    //public void CheckInput()
    //{
    //    int input = int.Parse(xVal.text);
    //    Debug.Log("this number is " + (Good(input) * 100).ToString() + " percent within the good set in a 3 peak graph");
    //    Debug.Log("this number is " + (Grey(input) * 100).ToString() + " percent within the grey set in a 3 peak graph");
    //    Debug.Log("this number is " + (Evil(input) * 100).ToString() + " percent within evil set in a 3 peak graph");
    //}


    //public override float Evil(float x)
    //{
    //    min = 0;
    //    max = 50;
    //    mid = 25;
    //    return (Triangle(x, min, mid, max));
    //}
    //public override float Grey(float x)
    //{
    //    min = 25;
    //    max = 75;
    //    mid = 50;
    //    return (Triangle(x, min, mid, max));
    //}

    //public override float Good(float x)
    //{
    //    min = 50;
    //    max = 100;
    //    mid = 75;
    //    return (Triangle(x, min, mid, max));
    //}

}
