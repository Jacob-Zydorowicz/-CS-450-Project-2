/*
 * (Jacob Welch)
 * (BuildingFactory)
 * (CitySim)
 * (Description: Handles the spawning of buildings.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour
{
    #region Fields
    [Tooltip("The default building that will be spawned if none are given to the factory.")]
    [SerializeField] private GameObject defaultBuilding;

    [Tooltip("The List of currently placeable buildings")]
    [SerializeField] private List<GameObject> placableBuildings = new List<GameObject>();

    /// <summary>
    /// The instance in the scene of the building factory.
    /// </summary>
    private static BuildingFactory Instance;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes components.
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Spawns the default building.
    /// </summary>
    /// <returns></returns>
    public static Building SpawnBuilding()
    {
        if (Instance == null) return null;

        return Instantiate(Instance.defaultBuilding).GetComponent<Building>();
    }

    /// <summary>
    /// Spawns the building at the given index.
    /// </summary>
    /// <param name="buildingNumber">The building index that should be spawned.</param>
    /// <returns></returns>
    public static Building SpawnBuilding(int buildingNumber)
    {
        if (Instance == null) return null;
        if (buildingNumber >= Instance.placableBuildings.Count) return SpawnBuilding();

        var building = Instantiate(Instance.placableBuildings[buildingNumber], new Vector2(1000, 1000), Quaternion.identity).GetComponent<Building>();

        return building;
    }

    /// <summary>
    /// The number of buildings that can currently be spawned.
    /// </summary>
    /// <returns></returns>
    public static int NumberOfBuildings()
    {
        return Instance.placableBuildings.Count;
    }
    #endregion
}