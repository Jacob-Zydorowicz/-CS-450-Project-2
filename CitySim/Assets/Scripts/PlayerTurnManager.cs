/*
 * (Jacob Welch)
 * (PlayerTurnManager)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    #region Fields
    private List<Command> buildingCommands = new List<Command>();
    private static int turn;
    private static Subject sb;
    private static PlayerTurnManager Instance;
    #endregion

    #region Functions
    private void Awake()
    {
        Instance = this;
        turn = 1;
        sb = FindObjectOfType<Subject>();
        sb.UpdateTurn(turn);
    }

    public static void AddCommand(Command commandExecuted)
    {
        Instance.buildingCommands.Add(commandExecuted);
    }

    public static void RemoveCommand()
    {

    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && buildingCommands.Count != 0)
        {
            buildingCommands[buildingCommands.Count-1].Undo();
            buildingCommands.RemoveAt(buildingCommands.Count-1);
        }
    }

    public static void NextTurn()
    {
        turn++;
        sb.UpdateTurn(turn);
        foreach(Building building in GameObject.FindObjectsOfType<Building>())
        {
            building.TurnEffect();
        }
        Instance.buildingCommands.Clear();
    }
    #endregion
}
