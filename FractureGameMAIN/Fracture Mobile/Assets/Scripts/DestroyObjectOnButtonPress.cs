using UnityEngine;
using System.Collections;

public class DestroyObjectsOnButtonPress : MonoBehaviour
{
    public BoxCollider triggerCollider;
    public int maxCharges = 3; // Maximum number of charges
    public float cooldownTime = 10f; // Cooldown time in seconds

    private int currentCharges;
    private bool isCooldownActive = false;

    private void Start()
    {
        // Initialize charges
        currentCharges = maxCharges;
    }

    public void DestroyObjectsInFront()
    {
        if (currentCharges > 0 && !isCooldownActive)
        {
            // Perform the action
            Collider[] hitColliders = Physics.OverlapBox(triggerCollider.bounds.center, triggerCollider.bounds.extents, triggerCollider.transform.rotation);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider != triggerCollider && hitCollider.gameObject != gameObject) // Ensure the triggerCollider and the player itself are not destroyed
                {
                    Destroy(hitCollider.gameObject);
                }
            }

            // Decrease the charge count
            currentCharges--;

            // Start cooldown if charges are depleted
            if (currentCharges == 0)
            {
                StartCoroutine(RechargeCharges());
            }
        }
        else if (isCooldownActive)
        {
            Debug.Log("Action is on cooldown. Please wait.");
        }
        else
        {
            Debug.Log("No charges left.");
        }
    }

    private IEnumerator RechargeCharges()
    {
        isCooldownActive = true;

        while (currentCharges < maxCharges)
        {
            yield return new WaitForSeconds(cooldownTime);
            currentCharges++;
            Debug.Log($"Charge recharged. Current charges: {currentCharges}");
        }

        isCooldownActive = false;
    }
}