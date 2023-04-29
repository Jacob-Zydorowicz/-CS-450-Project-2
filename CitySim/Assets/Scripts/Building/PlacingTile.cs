/*
 * (Jacob Welch)
 * (PlacingTile)
 * (#PROJECTNAME#)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTile : MonoBehaviour
{
    #region Fields
    [Tooltip("Set to false if this location is an invalid tile")]
    [SerializeField] private bool CanPlaceHere = true;

    public PlayerBuildController.ValidLocationState IsValidLocation 
    {
        get
        {
            if(CanPlaceHere && BuildingOnLocation == null)
            {
                return PlayerBuildController.ValidLocationState.VALID;
            }
            else if(BuildingOnLocation != null)
            {
                return PlayerBuildController.ValidLocationState.HASBUILDING;
            }
            else
            {
                return PlayerBuildController.ValidLocationState.INVALID;
            }
        } 
    }

    [field: SerializeField] public Building BuildingOnLocation;
    #endregion

    #region Functions
    /// <summary>
    /// Sets the building at this location. Set this to null when removing building.
    /// </summary>
    /// <param name="newBuilding">The new building on this location.</param>
    public void SetBuilding(Building newBuilding)
    {
        BuildingOnLocation = newBuilding;
    }
    #endregion
}
