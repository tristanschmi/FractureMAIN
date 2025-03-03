using System;
using UnityEngine;

public class TriggerGameActionBehaviour : MonoBehaviour
{
    public GameAction action;
    private bool hasActionBeenRaised = false;
    public GameActionListener gameActionListener;

    public void OnTriggerEnter(Collider other)
    {
        if (!hasActionBeenRaised)
        {
            Transform spawnLocation = transform.Find("SpawnLocation");
            if (spawnLocation != null)
            {
                gameActionListener.SetInstantiateLocation(spawnLocation);
                action.RaiseNoArgs();
                hasActionBeenRaised = true;
            }
            else
            {
                Debug.LogError("SpawnLocation not found on " + gameObject.name);
            }
        }
    }
}