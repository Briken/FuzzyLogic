using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GraphNs;

public class GraphManager : MonoBehaviour {

    public float[] defuzConfR;
    public float[] defuzConfL;
    public float confSum;
    public float numerator;
    public float[] defuzConfM;

    float xMax;
    float xMin;

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
        xMax = 100;
        xMin = 0;

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
        float nCrisp = DefuzzifyMorality();
        Debug.Log("new crisp value " + nCrisp.ToString());
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

    float DefuzzifyMorality()
    {
        
        float tLP = (neutral.GetMin() + (neutral.GetMid() - neutral.GetMin()) * fuzzyNeutral);
        float tRP = (neutral.GetMax() + (neutral.GetMid() - neutral.GetMax()) * fuzzyNeutral);
        float crispDefuz = 0;

        Trapezoid defuzPeak = new Trapezoid(25, tLP, tRP, 75, fuzzyNeutral);
        LeftShoulderGraph defuzL = new LeftShoulderGraph(25, 50, fuzzyEvil);
        RightShoulderGraph defuzR = new RightShoulderGraph(50, 75, fuzzyGood);

        float eRepValue;
        float nRepValue;
        float gRepValue;

        eRepValue = (defuzL.GetMin() + xMin) / 2;
        nRepValue = (defuzPeak.GetLMax() + defuzPeak.GetRMin()) / 2;
        gRepValue = (defuzR.GetMax() + xMax) / 2;

        float numerator = (eRepValue * fuzzyEvil) + (nRepValue * fuzzyNeutral) + (gRepValue * fuzzyGood);
        float denominator = (fuzzyEvil + fuzzyGood + fuzzyNeutral);
        crispDefuz = numerator / denominator;
        return crispDefuz;
    }

    float DefuzzifyChaos()
    {

        float lTLP = (lawful.GetMin() + (lawful.GetMid() - lawful.GetMin()) * fuzzyLaw);
        float lTRP = (lawful.GetMax() + (lawful.GetMid() - lawful.GetMax()) * fuzzyLaw);

        float nTLP = (cNeutral.GetMin() + (cNeutral.GetMid() - cNeutral.GetMin()) * fuzzyCNeutral);
        float nTRP = (cNeutral.GetMax() + (cNeutral.GetMid() - cNeutral.GetMax()) * fuzzyCNeutral);

        float cTRP = (chaotic.GetMin() + (chaotic.GetMid() - chaotic.GetMin()) * fuzzyChaos);
        float cTLP = (chaotic.GetMax() + (chaotic.GetMid() - chaotic.GetMax()) * fuzzyChaos);


        float crispDefuz = 0;

        Trapezoid lawfulDefuz = new Trapezoid(lawful.GetMin(), lTLP, lTRP, lawful.GetMax(), fuzzyNeutral);
        Trapezoid chaosDefuz = new Trapezoid(chaotic.GetMin(), cTLP, cTRP, chaotic.GetMax(), fuzzyChaos);
        Trapezoid cNeutralDefuz = new Trapezoid(cNeutral.GetMin(), nTLP, nTRP, cNeutral.GetMax(), fuzzyCNeutral);

        float lRepValue;
        float nRepValue;
        float cRepValue;

        lRepValue = (lawfulDefuz.GetLMax() + lawfulDefuz.GetRMin()) / 2;
        nRepValue = (cNeutralDefuz.GetLMax() + cNeutralDefuz.GetRMin()) / 2;
        cRepValue = (chaosDefuz.GetLMax() + chaosDefuz.GetRMin()) / 2;

        float numerator = (lRepValue * fuzzyLaw) + (nRepValue * fuzzyCNeutral) + (cRepValue * fuzzyChaos);
        float denominator = (fuzzyLaw + fuzzyCNeutral + fuzzyChaos);
        crispDefuz = numerator / denominator;
        return crispDefuz;
    }
}
