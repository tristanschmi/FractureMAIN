using UnityEngine;

public class GameActionListener : MonoBehaviour
{
    public GameAction gameAction;
    public GameObject prefabToInstantiate;
    private Transform instantiateLocation;

    private void OnEnable()
    {
        gameAction.RaiseNoArgs += OnGameActionRaised;
    }

    private void OnDisable()
    {
        gameAction.RaiseNoArgs -= OnGameActionRaised;
    }

    private void OnGameActionRaised()
    {
        if (instantiateLocation != null)
        {
            GameObject newPrefab = Instantiate(prefabToInstantiate, instantiateLocation.position, instantiateLocation.rotation);
            // Update the instantiateLocation to the new prefab's spawn location
            instantiateLocation = newPrefab.transform.Find("SpawnLocation");
            gameAction.RaiseNoArgs -= OnGameActionRaised; // Unsubscribe to ensure it only happens once
        }
        else
        {
            Debug.LogError("Instantiate location is not set.");
        }
    }

    public void SetInstantiateLocation(Transform newLocation)
    {
        instantiateLocation = newLocation;
    }
}