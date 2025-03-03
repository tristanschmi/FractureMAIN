using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PrefabSpawner")]
public class PrefabSpawner : ScriptableObject
{
    public GameObject prefab;
    public Vector3 spawnLocation;

    public GameObject SpawnPrefab()
    {
        if (prefab != null)
        {
            return Instantiate(prefab, spawnLocation, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned.");
            return null;
        }
    }
}