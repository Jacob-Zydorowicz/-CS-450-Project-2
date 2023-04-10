/*
 * (Jacob Welch)
 * (MoneyBoostAbility)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBoostAbility : BuildingAbility
{
    #region Fields
    [Tooltip("The amount of money the player should gain at the start of a turn from this building")]
    [SerializeField] private float moneyToGain = 100;
    #endregion

    #region Functions
    public override void PerformAbility()
    {
        print("Gain " + moneyToGain + " Money");
    }
    #endregion
}
