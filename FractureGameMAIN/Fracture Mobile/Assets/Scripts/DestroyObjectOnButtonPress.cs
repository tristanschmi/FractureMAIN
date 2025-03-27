using UnityEngine;

public class DestroyObjectsOnButtonPress : MonoBehaviour
{
    public BoxCollider triggerCollider;

    public void DestroyObjectsInFront()
    {
        Collider[] hitColliders = Physics.OverlapBox(triggerCollider.bounds.center, triggerCollider.bounds.extents, triggerCollider.transform.rotation);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != triggerCollider && hitCollider.gameObject != gameObject) // Ensure the triggerCollider and the player itself are not destroyed
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }
}