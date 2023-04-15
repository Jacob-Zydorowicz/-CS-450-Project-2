/*
 * (Jacob Welch, Jacob Zydorowicz)
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
    private int shopIndex;
    private int currentBuildCost=0;
    private int currentBuildingIndex = -1;
    private Building currentBuilding;
    private bool hasValidLocation = false;

    public AudioSource playerBuildClips;
    public AudioClip shopBuyClip;
    public AudioClip shopDenyClip;
    public AudioClip placeBuildingClip;
    

    private PlacingTile currentPlacingTile;

    private List<Building> recentlyPlacedBuildings = new List<Building>();
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Start()
    {
        ResetBuilding();
    }

    public void ResetBuilding(int newIndex = 0)
    {
        if (newIndex <= -1) return;
        var newBuilding = BuildingFactory.SpawnBuilding(newIndex);

        if(newBuilding != null)
        {
            if (currentBuilding != null) Destroy(currentBuilding.gameObject);

            shopIndex = newIndex;
            currentBuildingIndex = newIndex;
            currentBuilding = newBuilding;
        }
    }

    public void Execute()
    {
        PlaceBuilding();
        playerBuildClips.PlayOneShot(placeBuildingClip);
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
            if(EconManager.Buy(currentBuilding.GetData.Money))
            {
                playerBuildClips.PlayOneShot(shopBuyClip);
                Execute();
            }
            else
            {
                playerBuildClips.PlayOneShot(shopDenyClip);
            }
        }

        ChangeActiveBuilding();
    }
    /// <summary>
    /// Method <c>getBuildingFromShop</c> Uses shop buttons to set the active building
    /// <paramref name="buildingIndex"/> index assigned from shop that corresponds to factory lsit. Need assign in scence shop buttons
    /// </summary>
    public void getBuildingFromShop(int buildingIndex)
    {
        shopIndex = buildingIndex;
        
    }
    /// <summary>
    /// Method <c>getPriceFromShop</c> Uses shop buttons to set the active building price
    /// <paramref name="price"/> cost to place the building. Need assign in scence shop buttons
    /// </summary>
    public void getPriceFromShop(int price)
    {
        currentBuildCost = price;
    }

    private void ChangeActiveBuilding()
    {
        ChangeActiveBuildingMouse(shopIndex);
        ChangeActiveBuildingKeys();
    }

    private void ChangeActiveBuildingMouse(int shopIndex)
    {
        switch (shopIndex)
        {
            case 0:
                if (currentBuildingIndex != 0)
                    ResetBuilding(0);
                break;
            case 1:
                if (currentBuildingIndex != 1)
                    ResetBuilding(1);
                break;
            case 2:
                if (currentBuildingIndex != 2)
                    ResetBuilding(2);
                break;
            case 3:
                if (currentBuildingIndex != 3)
                    ResetBuilding(3);
                break;
            case 4:
                if (currentBuildingIndex != 4)
                    ResetBuilding(4);
                break;
            case 5:
                if (currentBuildingIndex != 5)
                    ResetBuilding(5);
                break;
            case 6:
                if (currentBuildingIndex != 6)
                    ResetBuilding(6);
                break;
            case 7:
                if (currentBuildingIndex != 7)
                    ResetBuilding(7);
                break;
            case 8:
                if (currentBuildingIndex != 8)
                    ResetBuilding(8);
                break;
            case 9:
                if (currentBuildingIndex != 9)
                    ResetBuilding(9);
                break;
            case 10:
                if (currentBuildingIndex != 10)
                    ResetBuilding(10);
                break;
            case 11:
                if (currentBuildingIndex != 11)
                    ResetBuilding(11);
                break;
            case 12:
                if (currentBuildingIndex != 12)
                    ResetBuilding(12);
                break;
            case 13:
                if (currentBuildingIndex != 13)
                    ResetBuilding(13);
                break;
            case 14:
                if (currentBuildingIndex != 14)
                    ResetBuilding(14);
                break;
        }

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
