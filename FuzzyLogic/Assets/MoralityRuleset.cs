using UnityEngine;
using System.Collections;

public class MoralityRuleset
{ 
    public string MoralityAlignment(float fGood, float fNeutral, float fEvil)
    {
        if (fGood > fEvil && fGood > fNeutral)
        {
            return "Good";
        }
        if (fNeutral > fGood && fNeutral > fEvil)
        {
            return "Neutral";
        }
        if (fEvil > fGood && fEvil > fNeutral)
        {
            return "Evil";
        }

        return "";
    }
    public string ChaoticAlignment(float fLawful, float fCNeutral, float fChaotic)
    {
        //if ()
        //{ }
        //if ()
        //{ }
        //if ()
        //{ }
        return "";
    }
}
