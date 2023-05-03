/*
 * (Jacob Welch)
 * (BuildingPlacementRequirement)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementRequirement : MonoBehaviour
{
    #region Fields
    [SerializeField] private string tagRequirement = "";

    [SerializeField] private bool shouldCheckMoneyRequirement = false;
    #endregion

    #region Functions
    public bool CheckRequirement(PlacingTile tileToCheckAround)
    {
        return CheckTagRequirement(tileToCheckAround) && CheckMaxMoneyRequirement();
    }

    private bool CheckTagRequirement(PlacingTile tileToCheckAround)
    {
        if (tagRequirement == "") return true;

        foreach (var tile in PlayerBuildController.CheckSurroundingPlacementTiles(tileToCheckAround))
        {
            if(tile.BuildingOnLocation != null)
            //print(tile.BuildingOnLocation.gameObject.tag);

            if (tile.BuildingOnLocation != null && tile.BuildingOnLocation.gameObject.CompareTag(tagRequirement))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckMaxMoneyRequirement()
    {
        if (shouldCheckMoneyRequirement)
        {
            var shoppingObj = GameObject.Find("Shopping Center(Clone)");

            if (shoppingObj)
            {
                return shoppingObj.GetComponent<Building>().GetCurrentState == Building.BuildingStateEnum.PLACED;
            }

            return false;
        }

        return true;
    }
    #endregion
}
