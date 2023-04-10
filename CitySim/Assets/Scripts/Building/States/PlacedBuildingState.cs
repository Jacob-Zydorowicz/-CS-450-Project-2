/*
 * (Jacob Welch)
 * (PlacedBuildingState)
 * (CitySim)
 * (Description: Handles the placed building state of all buildings. )
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlacedBuildingState : BuildingState
{
    #region Fields
    [field:SerializeField] public BuildingTurnData BuildingData { get; private set; }

    private List<BuildingAbility> buildingAbilities;
    #endregion

    #region Functions
    protected override void Awake()
    {
        base.Awake();
        buildingAbilities = GetComponentsInChildren<BuildingAbility>().ToList();
    }

    public override void BuildingTickEvent()
    {
        EconManager.AddMoney(BuildingData.Money);
        CO2Manager.UpdateCO2(BuildingData.CO2);

        foreach(BuildingAbility ability in buildingAbilities)
        {
            ability.PerformAbility();
        }
    }
    #endregion
}
