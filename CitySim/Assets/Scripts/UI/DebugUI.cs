using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DebugUI : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftBracket))
        {
            EconManager.AddMoney(100);
        }

        if(Input.GetKeyDown(KeyCode.RightBracket))
        {
            EconManager.Buy(100);
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            CO2Manager.UpdateCO2(5);
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            CO2Manager.UpdateCO2(-5);
        }

        if(Input.GetKeyDown(KeyCode.Semicolon))
        {
            PlayerTurnManager.NextTurn();
        }
    }
}
