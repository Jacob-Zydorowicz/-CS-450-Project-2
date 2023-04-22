/*
 * (Jacob Welch, Jacob Zydorowicz)
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
    [SerializeField] int maxTurns = 50;
    [SerializeField] float baseCO2rate = .1f;
    [SerializeField] float CO2RateOfIncrease = .4f;
    private static int turn;
    private static Subject sb;
    private static PlayerTurnManager Instance;

    public AudioSource undoSource;
    public AudioClip undoClip;
    #endregion

    #region Functions
    private void Awake()
    {
        Instance = this;
        turn = 1;
        sb = FindObjectOfType<Subject>();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Undo();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Debug.Log("next turn");
            NextTurn();
        }
    }

    public void Undo()
    {
        if (buildingCommands.Count != 0 && Time.timeScale != 0)
        {
            buildingCommands[buildingCommands.Count - 1].Undo();
            buildingCommands.RemoveAt(buildingCommands.Count - 1);
            undoSource.PlayOneShot(undoClip);
        }

        
    }


    public void NextTurn()
    {
        if (Time.timeScale != 0)
        {
            turn++;
            CO2Manager.UpdateCO2((baseCO2rate + CO2RateOfIncrease * (turn - 1)));
            sb.UpdateTurn(turn);
            foreach (Building building in GameObject.FindObjectsOfType<Building>())
            {
                building.TurnEffect();
            }
            Instance.buildingCommands.Clear();
            if (turn >= maxTurns)
                GameObject.FindObjectOfType<ExtraMenusController>().Win();
        }
    }
    #endregion
}
