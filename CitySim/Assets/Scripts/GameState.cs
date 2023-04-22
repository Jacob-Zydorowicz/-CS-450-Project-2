using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public CO2Manager co2manager;
    public PlayerTurnManager playerTurnManager;

    private void Awake()
    {
        co2manager = GetComponent<CO2Manager>();
        playerTurnManager = GetComponent<PlayerTurnManager>();
    }

    //public void Win()
    //{
    //    if (playerTurnManager.maxTurn)
    //    {

    //    }
    //}

    //public void Lose()
    //{
    //    if (co2manager.gameOver)
    //    {
    //        //trigger the game over screen, switch to lose screen
    //    }
    //}
}
