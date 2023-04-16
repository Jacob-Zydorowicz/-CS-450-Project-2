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

    private Dictionary<string, GameObject> buildingDictionary = new Dictionary<string, GameObject>();

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
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        foreach(GameObject obj in placableBuildings)
        {
            buildingDictionary.Add(obj.name, obj);
        }
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
    public static Building SpawnBuilding(string buildingName)
    {
        if (Instance == null) return null;

        Building building = null;

        if(Instance.buildingDictionary.TryGetValue(buildingName, out GameObject buildingToSpawn))
        {
            building = Instantiate(buildingToSpawn, new Vector2(1000, 1000), Quaternion.identity).GetComponent<Building>();
        }

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

[System.Serializable]
public class BuildingNamePair
{
    [field:Tooltip("The data for the building that is to be spawned")]
    [field:SerializeField]
    public BuildingTurnData buildingData { get; private set; }

    [field:Tooltip("The building object to spawn for this data")]
    [field:SerializeField]
    public GameObject building { get; private set; }
}