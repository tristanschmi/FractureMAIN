using UnityEngine;

public class DecreaseIntDataOnTrigger : MonoBehaviour
{
    public IntData intData;
    public int decreaseAmount = 1;

    private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("DecreaseTrigger"))
    {
        Debug.Log("Trigger detected. Decreasing value.");
        intData.UpdateValue(-decreaseAmount);
    }
}
}