using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnObserver : Observer
{
    int currentTurn;
    [SerializeField] TextMeshProUGUI counter; 
    // Start is called before the first frame update
    void Start()
    {
        currentTurn = 1;
        counter.text = "Turn: 1";
    }

    public override void UpdateVal(int money, float CO2, int turn)
    {
        currentTurn = turn;
        counter.text = "Turn: " + turn;
    }
}
