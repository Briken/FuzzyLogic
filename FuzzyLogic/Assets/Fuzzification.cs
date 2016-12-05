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
//float crispDefuz = 0;
//float lY = 0;
//float lZ = 0;
//float pY = 0;
//float pZ = 0;
//float rY = 0;
//float rZ = 0;

////float tLP = (fuzzyNeutral * (50-25) + 25);
//float tLP = (25 + (50 - 25) * fuzzyNeutral);
//float tRP = (50 + (75 - 50) * fuzzyNeutral);

//Trapezoid defuzPeak = new Trapezoid(25, tLP, tRP, 75, fuzzyNeutral);
//LeftShoulderGraph defuzL = new LeftShoulderGraph(25, 50, fuzzyEvil);
//RightShoulderGraph defuzR = new RightShoulderGraph(50, 75, fuzzyGood);
//        for (int x = 0; x<defuzConfL.GetLength(0); x++)
//        {
//            lZ = defuzL.CheckIfContained(defuzConfL[x]);
//            pZ = defuzPeak.CheckIfContained(defuzConfM[x]);
//            rZ = defuzR.CheckIfContained(defuzConfR[x]);
//            confSum += (lZ + pZ + rZ);
            
//            defuzConfL[x] = defuzL.CheckIfContained(defuzConfL[x]) * defuzConfL[x];
//Debug.Log(defuzConfL[x].ToString() + " confidence level at pass number " + x.ToString() + " in left Shoulder");
//            defuzConfR[x] = defuzR.CheckIfContained(defuzConfR[x])* defuzConfR[x];
//Debug.Log(defuzConfR[x].ToString() + " confidence level at pass number " + x.ToString() + " in right Shoulder");
//            defuzConfM[x] = defuzPeak.CheckIfContained(defuzConfM[x])* defuzConfM[x];
//Debug.Log(defuzConfM[x].ToString() + " confidence level at pass number " + x.ToString() + " in mid peak");
//        }

//        for (int x = 0; x<defuzConfL.GetLength(0); x++)
//        {
//            rY += defuzConfR[x];
//            lY += defuzConfL[x];
//            pY += defuzConfM[x];
//        }

//        crispDefuz = (rY + lY + pY) / confSum;
