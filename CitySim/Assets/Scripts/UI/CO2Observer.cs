using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CO2Observer : Observer
{
    [SerializeField] float maxCO2;
    float currentCO2 = 0;
    [SerializeField] Image fillBar;
    [SerializeField] Gradient gd;

    private void Awake()
    {
        fillBar.fillAmount = 0;
    }

    public override void UpdateVal(int money, float CO2, int turn)
    {
        currentCO2 = CO2;
        fillBar.fillAmount = CO2 / maxCO2;
        fillBar.color = gd.Evaluate(CO2 / maxCO2);
    }
}
