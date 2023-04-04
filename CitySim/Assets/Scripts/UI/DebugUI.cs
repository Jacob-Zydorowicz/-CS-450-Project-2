using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DebugUI : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EconManager.AddMoney(100);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            EconManager.Buy(100);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CO2Manager.UpdateCO2(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CO2Manager.UpdateCO2(-5);
        }
    }
}
