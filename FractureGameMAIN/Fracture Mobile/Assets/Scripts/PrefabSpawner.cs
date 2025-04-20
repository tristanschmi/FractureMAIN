using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnLocation; // Input spawn location in the Inspector

    public GameObject SpawnPrefabAt(Vector3? customSpawnLocation = null)
    {
        if (prefab != null)
        {
            // Use the custom spawn location if provided, otherwise use the Inspector value
            Vector3 finalSpawnLocation = customSpawnLocation ?? spawnLocation;

            // Spawn the prefab at the specified location
            return Instantiate(prefab, finalSpawnLocation, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned.");
            return null;
        }
    }
}