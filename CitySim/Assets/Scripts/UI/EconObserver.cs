using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconObserver : Observer
{
    int currentMoney;
    [SerializeField] TextMeshProUGUI counter;

    private void Awake()
    {
        counter.text = "Cash: $0"; 
    }
    public override void UpdateVal(int money, float CO2, int turn)
    {
        counter.text = "Cash: $" + money;
    }
}
