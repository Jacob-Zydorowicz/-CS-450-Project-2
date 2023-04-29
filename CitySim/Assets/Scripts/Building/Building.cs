/*
 * (Jacob Welch)
 * (Building)
 * (CitySim)
 * (Description: A base class of functionalities for all buildings.)
 */
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ValidPreviewBuildingState), typeof(InvalidPreviewBuildingState), typeof(PlacedBuildingState))]
[RequireComponent(typeof(SpriteRenderer))]
public class Building : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The states for whether or not a location should be checked in the array.
    /// </summary>
    public enum CheckState { CENTER, CHECK, DONTCHECK }

    /// <summary>
    /// An array that defines the locaitons to check relative to the building when it is being placed.
    /// </summary>
    public ListWrapper[] locationToCheck = new ListWrapper[0];

    /// <summary>
    /// The sprite renderer of the building.
    /// </summary>
    private SpriteRenderer buildingSpriteRenderer;

    #region Building States
    /// <summary>
    /// All of the states the building can be in.
    /// </summary>
    public enum BuildingStateEnum { PLACED, VALIDPREVIEW, INVALIDPREVIEW, DESTROY }

    public BuildingTurnData GetData
    {
        get
        {
            return placedBuildingState.BuildingData;
        }
    }

    public BuildingStateEnum GetCurrentState
    {
        get
        {
            if(currentBuildingState == validBuildingState)
            {
                return BuildingStateEnum.VALIDPREVIEW;
            }
            else if(currentBuildingState == placedBuildingState)
            {
                return BuildingStateEnum.PLACED;
            }
            else
            {
                return BuildingStateEnum.INVALIDPREVIEW;
            }
        }
    }

    // All of the states that the tower has.
    private BuildingState currentBuildingState;
    private ValidPreviewBuildingState validBuildingState;
    private InvalidPreviewBuildingState invalidPreviewBuildingState;
    private PlacedBuildingState placedBuildingState;
    #endregion
    #endregion

    #region Functions
    /// <summary>
    /// Initializes all of the components of the building.
    /// </summary>
    private void Awake()
    {
        buildingSpriteRenderer = GetComponent<SpriteRenderer>();
        validBuildingState = GetComponent<ValidPreviewBuildingState>();
        invalidPreviewBuildingState = GetComponent<InvalidPreviewBuildingState>();
        placedBuildingState = GetComponent<PlacedBuildingState>();

        currentBuildingState = invalidPreviewBuildingState;
    }

    /// <summary>
    /// Sets the color of the building.
    /// </summary>
    /// <param name="newBuildingColor">The new color for the building to have.</param>
    public void SetBuildingColor(Color newBuildingColor)
    {
        buildingSpriteRenderer.color = newBuildingColor;
    }

    /// <summary>
    /// Sets the new sprite the building should use.
    /// </summary>
    /// <param name="newBuildingSprite">The new sprite applied to the buildings sprite renderer.</param>
    public void SetBuildingSprite(Sprite newBuildingSprite)
    {
        if (newBuildingSprite == null) return;

        buildingSpriteRenderer.sprite = newBuildingSprite;
    }

    /// <summary>
    /// Sets the new material the building should use.
    /// </summary>
    /// <param name="newMaterial">The new material applied to the buildigns sprite rendrer.</param>
    public void SetBuildingMaterial(Material newMaterial)
    {
        if (newMaterial == null) return;

        buildingSpriteRenderer.material = newMaterial;
    }

    /// <summary>
    /// Calls for the current building states tick event to take place.
    /// </summary>
    private void Update()
    {
        //currentBuildingState.BuildingTickEvent();
    }

    ///<summary>
    ///Calls the current building state every turn
    ///</summary>
    public void TurnEffect()
    {
        currentBuildingState.BuildingTickEvent();
    }

    /// <summary>
    /// Changes the current active state to be used by the building.
    /// </summary>
    /// <param name="buildingState">The new state the building should take.</param>
    public void SetBuildingState(BuildingStateEnum buildingState)
    {
        switch (buildingState)
        {
            case BuildingStateEnum.PLACED:
                placedBuildingState.SetStateActive();
                currentBuildingState = placedBuildingState;
                break;
            case BuildingStateEnum.VALIDPREVIEW:
                validBuildingState.SetStateActive();
                currentBuildingState = validBuildingState;
                break;
            case BuildingStateEnum.INVALIDPREVIEW:
                invalidPreviewBuildingState.SetStateActive();
                currentBuildingState = invalidPreviewBuildingState;
                break;
            default:
                break;
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
    #endregion
}

[System.Serializable]
public class ListWrapper
{
    [ShowInInspector]
    [Tooltip("The row for this check area")]
    [SerializeField] private List<Building.CheckState> rowCheckList = new List<Building.CheckState>();
}
