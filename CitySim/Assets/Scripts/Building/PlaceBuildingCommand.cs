/*
 * (Jacob Welch)
 * (PlaceBuildingCommand)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuildingCommand : Command
{
    #region Fields
    private Stack<Building> previouslyPlaceBuildings = new Stack<Building>();
    private PlayerBuildController playerBuildController;
    #endregion

    #region Functions
    public PlaceBuildingCommand(PlayerBuildController playerBuildController)
    {
        this.playerBuildController = playerBuildController;
    }

    public void Execute()
    {
        EconManager.Buy(playerBuildController.currentBuilding.GetData.Money);

        //PlayerTurnManager.AddCommand(this);

        playerBuildController.currentPlacingTile.SetBuilding(playerBuildController.currentBuilding);
        playerBuildController.currentBuilding.SetBuildingState(Building.BuildingStateEnum.PLACED);
        previouslyPlaceBuildings.Push(playerBuildController.currentBuilding);

        playerBuildController.currentBuilding = null;
        playerBuildController.ResetBuilding(playerBuildController.currentBuildingName);
    }

    public void Undo()
    {
        var building = previouslyPlaceBuildings.Pop();
        //playerBuildController.GetTileAtLocation(recentlyPlacedBuildings[recentlyPlacedBuildings.Count - 1].transform.position).SetBuilding(null);
        EconManager.Buy(-building.GetData.Money);
        building.Delete();
    }
    #endregion
}
