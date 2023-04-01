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
    [field:SerializeField] public bool isValidLocation { get; private set; } = true;
    #endregion

    #region Functions
    public void ChangeValidState(bool newState)
    {
        isValidLocation = newState;
    }
    #endregion
}
