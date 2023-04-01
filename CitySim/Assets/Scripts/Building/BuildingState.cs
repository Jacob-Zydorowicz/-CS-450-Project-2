/*
 * (Jacob Welch)
 * (BuildingState)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingState : MonoBehaviour
{
    #region Fields
    [SerializeField] private Color stateColor;

    private Building building;
    #endregion

    #region Functions
    private void Awake()
    {
        building = GetComponent<Building>();
    }

    public virtual void SetStateActive()
    {
        building.SetBuildingColor(stateColor);
    }

    public abstract void BuildingTickEvent();
    #endregion
}
