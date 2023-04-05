/*
 * (Jacob Welch)
 * (PlayerBuildController)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBuildController : MonoBehaviour, Command
{
    #region Fields
    private int currentBuildingIndex = 0;
    private Building currentBuilding;
    private bool hasValidLocation = false;

    private PlacingTile currentPlacingTile;

    private List<Building> recentlyPlacedBuildings = new List<Building>();
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        ResetBuilding();
    }

    public void ResetBuilding(int newIndex = 0)
    {
        if (newIndex == -1) return;
        if (currentBuilding != null) Destroy(currentBuilding.gameObject);

        currentBuildingIndex = newIndex;
        currentBuilding = BuildingFactory.SpawnBuilding(currentBuildingIndex);
    }

    public void Execute()
    {
        PlaceBuilding();
    }

    public void Undo()
    {
        GetTileAtLocation(recentlyPlacedBuildings[recentlyPlacedBuildings.Count - 1].transform.position).ChangeValidState(true);
        Destroy(recentlyPlacedBuildings[recentlyPlacedBuildings.Count-1].gameObject);
        recentlyPlacedBuildings.RemoveAt(recentlyPlacedBuildings.Count - 1);
    }

    private void PlaceBuilding()
    {
        if (hasValidLocation)
        {
            PlayerTurnManager.AddCommand(this);
            currentPlacingTile.ChangeValidState(false);
            currentBuilding.SetBuildingState(Building.BuildingStateEnum.PLACED);
            recentlyPlacedBuildings.Add(currentBuilding);
            currentBuilding = null;
            ResetBuilding(currentBuildingIndex);
        }
    }

    #region Player Input
    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        if (currentBuilding == null) return;

        CheckForPlacingTile();
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Execute();
        }

        ChangeActiveBuilding();
    }

    private void ChangeActiveBuilding()
    {
        ChangeActiveBuildingMouse();
        ChangeActiveBuildingKeys();
    }

    private void ChangeActiveBuildingMouse()
    {
        /*
        if(Input.mouseScrollDelta > 0)
        {
            ResetBuilding(++currentBuildingIndex);
        }
        else
        {
            ResetBuilding(--currentBuildingIndex);
        }*/
    }

    private void ChangeActiveBuildingKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentBuildingIndex != 0)
                ResetBuilding(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentBuildingIndex != 1)
                ResetBuilding(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentBuildingIndex != 2)
                ResetBuilding(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentBuildingIndex != 3)
                ResetBuilding(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (currentBuildingIndex != 4)
                ResetBuilding(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (currentBuildingIndex != 5)
                ResetBuilding(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (currentBuildingIndex != 6)
                ResetBuilding(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (currentBuildingIndex != 7)
                ResetBuilding(7);
        }
    }
    #endregion

    #region Checking tile locations
    private void CheckForPlacingTile()
    {
        currentPlacingTile = GetTileAtLocation(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if(currentPlacingTile)
        {
            hasValidLocation = CheckValidLocations(currentPlacingTile);
            currentBuilding.transform.position = currentPlacingTile.transform.position;

            Building.BuildingStateEnum buildingState = hasValidLocation ? Building.BuildingStateEnum.VALIDPREVIEW : Building.BuildingStateEnum.INVALIDPREVIEW;
            currentBuilding.SetBuildingState(buildingState);
        }
        else
        {
            hasValidLocation = false;
        }
    }

    private PlacingTile GetTileAtLocation(Vector3 position)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform && hit.transform.gameObject.TryGetComponent(out PlacingTile placingTile))
            {
                return placingTile;
            }
        }

        return null;
    }

    private bool CheckValidLocations(PlacingTile placingTile)
    {
        switch (currentBuilding.locationToCheck.Length)
        {
            case 1:
                return placingTile.isValidLocation;
            case 2:
                return placingTile.isValidLocation;
            case 0:
            default:
                return false;
        }
    }
    #endregion
    #endregion
}
