/*
 * (Jacob Welch)
 * (Command)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    #region Functions
    public void Execute();

    public void Undo();
    #endregion
}
