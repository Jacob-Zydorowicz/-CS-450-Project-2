/*
 * (Jacob Welch)
 * (ReturnMoneyAbility)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMoneyAbility : BuildingAbility
{
    #region Fields

    #endregion

    #region Functions
    private void Start()
    {
        enabled = false;
    }

    public override void PerformAbility()
    {
        enabled = true;
    }
    #endregion
}
