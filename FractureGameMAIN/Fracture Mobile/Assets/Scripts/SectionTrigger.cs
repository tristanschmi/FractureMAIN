using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public PrefabSpawner prefabSpawner; // Reference to the PrefabSpawner

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player hits the trigger
        {
            // Spawn a new section at the location specified in the PrefabSpawner
            GameObject newSection = prefabSpawner.SpawnPrefabAt();

            if (newSection != null)
            {
                // Optionally, you can log the spawn for debugging
                Debug.Log($"Spawned new section at: {prefabSpawner.spawnLocation}");
            }
        }
    }
}