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
    private PlayerBuildController playerBuildController;
    #endregion

    #region Functions
    public DestroyBuildingCommand(PlayerBuildController playerBuildController)
    {
        this.playerBuildController = playerBuildController;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
