using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnValues : ScriptableObject
{
    public float CO2;
    public int Money;
    public abstract void Ability(GameObject go);
}
