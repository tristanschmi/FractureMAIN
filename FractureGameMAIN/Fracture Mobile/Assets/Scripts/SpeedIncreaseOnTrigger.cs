using UnityEngine;

public class SpeedIncreaseOnTrigger : MonoBehaviour
{
    public SpeedData speedData;
    public float speedIncrease = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedIncrease"))
        {
            speedData.speed += speedIncrease;
        }
    }
}