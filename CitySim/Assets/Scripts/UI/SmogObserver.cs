using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SmogObserver : Observer
{
    [SerializeField] float maxCO2;
    float currentCO2 = 0;
    [SerializeField] Image smog;

    private void Awake()
    {
        smog.color = new Color(smog.color.r, smog.color.g, smog.color.b, 0);
    }

    public override void UpdateVal(int money, float CO2, int turn)
    {
        currentCO2 = CO2;
        smog.color = new Color(smog.color.r, smog.color.g, smog.color.b, (0.5f)* CO2 / maxCO2); 
    }
}
