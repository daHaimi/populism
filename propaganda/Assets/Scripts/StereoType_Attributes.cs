using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Populism { 
    
public class StereoType_Attributes : MonoBehaviour {


    public float hate_Multiplier = 0;
    public float reason_Multiplier = 0;
    public float greed_Multiplier = 0;
    public float fun_Multiplier = 0;
    public float fear_Multiplier = 0;


    Propaganda propagandaAttributes;

    public float motivation = 0;


    public void becomeInfluenced(Propaganda propaganda)
    {
            propagandaAttributes.hate = hate_Multiplier * propaganda.hate;
            propagandaAttributes.reason = reason_Multiplier * propaganda.reason;
            propagandaAttributes.greed = greed_Multiplier * propaganda.greed;
            propagandaAttributes.fun = fun_Multiplier * propaganda.fun;
            propagandaAttributes.fear = fear_Multiplier * propaganda.fear;
    }

    public void CalculateMotivation()
    {
            motivation = (propagandaAttributes.hate + propagandaAttributes.reason + propagandaAttributes.greed + propagandaAttributes.fun + propagandaAttributes.fear) / 5;
    }

    // Use this for initialization
    void Start () {

            propagandaAttributes = new Propaganda();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
