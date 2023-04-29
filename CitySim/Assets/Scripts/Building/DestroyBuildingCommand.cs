/*
 * (Jacob Welch)
 * (DestroyBuildingCommand)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuildingCommand : Command
{
    #region Fields
    private Stack<Building> previouslyDestroyedBuildings = new Stack<Building>();
    private Stack<PlacingTile> previousPlacingTiles = new Stack<PlacingTile>();
    private Stack<bool> recieveMoneyFromUndo = new Stack<bool>();

    private PlayerBuildController playerBuildController;
    #endregion

    #region Functions
    public DestroyBuildingCommand(PlayerBuildController playerBuildController)
    {
        this.playerBuildController = playerBuildController;
    }

    public void Execute()
    {
        if (PlayerBuildController.RecieveMoneyFromDestroying)
        {
            EconManager.Buy(-playerBuildController.buildingToSell.GetData.Money);
            recieveMoneyFromUndo.Push(true);
        }
        else
        {
            recieveMoneyFromUndo.Push(false);
        }

        //PlayerTurnManager.AddCommand(this);

        playerBuildController.currentPlacingTile.SetBuilding(null);
        previouslyDestroyedBuildings.Push(playerBuildController.buildingToSell);
        previousPlacingTiles.Push(playerBuildController.currentPlacingTile);
        playerBuildController.buildingToSell.gameObject.SetActive(false);

        playerBuildController.buildingToSell = null;
    }

    public void Undo()
    {
        var building = previouslyDestroyedBuildings.Pop();
        var tile = previousPlacingTiles.Pop();
        var shouldRecieveMoney = recieveMoneyFromUndo.Pop();

        //playerBuildController.GetTileAtLocation(recentlyPlacedBuildings[recentlyPlacedBuildings.Count - 1].transform.position).SetBuilding(null);
        if(shouldRecieveMoney)
        EconManager.Buy(building.GetData.Money);
        building.gameObject.SetActive(true);

        tile.BuildingOnLocation = building;
    }

    public void Reset()
    {
        foreach(var obj in previouslyDestroyedBuildings)
        {
            obj.Delete();
        }

        previouslyDestroyedBuildings.Clear();
        previousPlacingTiles.Clear();
    }
    #endregion
}
