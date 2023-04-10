using Sirenix.OdinInspector;
using UnityEngine;

[InlineEditor]
[CreateAssetMenu(fileName = "New Tower Turn Values", menuName = "Tower Turn Data", order = 0)]
public class BuildingTurnData : ScriptableObject
{
    [field:Tooltip("The name of this building type")]
    [field:SerializeField]
    public string BuildingName { get; private set; }

    [field:Tooltip("The description of what this building is")]
    [field:SerializeField]
    public string BuildingDescription { get; private set; }

    [field:TextArea]
    [field:Tooltip("The description of what this building's ability does")]
    [field:SerializeField]
    public string AbilityDescription { get; private set; }

    [field:Range(-100, 100)]
    [field:Tooltip("The amount to adjust CO2 levels by")]
    [field:SerializeField]
    public float CO2 { get; private set; }

    [field:Range(0, 100000)]
    [field:Tooltip("The amount of money to charge for triggering this")]
    [field:SerializeField]
    public int Money { get; private set; }

    /// <summary>
    /// Initializes the scriptable objects values.
    /// </summary>
    public BuildingTurnData()
    {
        Money = 100;
    }
}
