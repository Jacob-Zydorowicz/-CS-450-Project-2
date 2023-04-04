using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundObserver : Observer
{
    [SerializeField] float maxCO2;
    float currentCO2 = 0;
    [SerializeField] Image smogEffect;

    private void Awake()
    {
        smogEffect.fillAmount = 0;
    }

    public override void UpdateVal(int money, float CO2, int turn)
    {
        currentCO2 = CO2;
        smogEffect.fillAmount = CO2 / maxCO2;
    }
}
