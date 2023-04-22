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

    public bool IsValidLocation 
    {
        get
        {
            return CanPlaceHere && BuildingOnLocation == null;
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
