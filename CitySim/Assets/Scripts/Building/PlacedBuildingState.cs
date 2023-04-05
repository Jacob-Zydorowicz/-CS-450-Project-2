/*
 * (Jacob Welch)
 * (PlacedBuildingState)
 * (CitySim)
 * (Description: Handles the placed building state of all buildings. )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingState : BuildingState
{
    #region Fields
    [SerializeField] private TurnValues values;
    #endregion

    #region Functions


    public override void BuildingTickEvent()
    {
        EconManager.AddMoney(values.Money);
        CO2Manager.UpdateCO2(values.CO2);
        values.Ability(gameObject);
    }
    #endregion
}
