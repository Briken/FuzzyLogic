using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GraphNs;

public class GraphManager : MonoBehaviour {

    float[] centroidDefuz;

    //Graph master;
    RightShoulderGraph good;
    Peak neutral;
    LeftShoulderGraph evil;

    Peak chaotic;
    Peak lawful;
    Peak cNeutral;

    MoralityRuleset rules;

    float morality;
    float chaos;

    string mAlignment;
    string cAlignment;

    private bool isGood;
    private bool isEvil;
    private bool isNeutral;

    float fuzzyGood;
    float fuzzyEvil;
    float fuzzyNeutral;

    float fuzzyChaos;
    float fuzzyLaw;
    float fuzzyCNeutral;

    public InputField xVal;
    //float value;

	// Use this for initialization
	void Start ()
    {
        centroidDefuz = new float[100];
        for (int x = 0; x < centroidDefuz.GetLength(0); x++)
        {
            centroidDefuz[x] = x;
        }
        //master = new Graph();
        good = new RightShoulderGraph(50, 75, 1.0f);
        neutral = new Peak(25, 50, 75, 1.0f);
        evil = new LeftShoulderGraph(25, 50, 1.0f);
        chaotic = new Peak(20, 60, 80, 1.0f);
        lawful = new Peak(0, 40, 80, 1.0f);
        cNeutral = new Peak(20, 50, 80, 0.75f);

        rules = new MoralityRuleset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fuzzify()
    { 
        morality = float.Parse(xVal.text);
        chaos = float.Parse(xVal.text);

        fuzzyGood = good.CheckIfContained(morality);
        fuzzyEvil = evil.CheckIfContained(morality);
        fuzzyNeutral = neutral.CheckIfContained(morality);
        fuzzyChaos = chaotic.CheckIfContained(chaos);
        fuzzyLaw = lawful.CheckIfContained(chaos);
        fuzzyCNeutral = cNeutral.CheckIfContained(chaos);

        Debug.Log("This number is held within the good set to " + fuzzyGood*100 + " degree");
        //if (fuzzyGood > fuzzyEvil &&  fuzzyGood > fuzzyNeutral)
        //{
        //    isGood = true;
        //}

        Debug.Log("This number is held within the grey set to " + fuzzyNeutral*100 + " degree");
        //if (fuzzyNeutral > fuzzyGood && fuzzyNeutral > fuzzyEvil)
        //{
        //    isNeutral = true;
        //}

        Debug.Log("This number is held within the evil set to " + fuzzyEvil*100 + " degree");
        //if (fuzzyEvil > fuzzyGood && fuzzyEvil > fuzzyNeutral)
        //{
        //    isEvil = true;
        //}

        Debug.Log(fuzzyChaos*100 + "this is chaos");
        Debug.Log(fuzzyLaw*100 + "this is lawful");
        mAlignment = DetermineAlignment(true);
        cAlignment = DetermineAlignment(false);
        Debug.Log("your alignment is " + cAlignment + " " + mAlignment);
    }



    string DetermineAlignment(bool morality)
    {
        string alignment;
        if (morality)
        {
            alignment = rules.MoralityAlignment(fuzzyGood, fuzzyNeutral, fuzzyEvil);
            return alignment;
        }
        alignment = rules.ChaoticAlignment(fuzzyLaw, fuzzyCNeutral, fuzzyChaos);
        return alignment;
    }

    float Defuzzify()
    {
        foreach (int x in centroidDefuz)
        {

        }

        return 0.0f;
    }
}
