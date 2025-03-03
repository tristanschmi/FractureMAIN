using UnityEngine;

public class MoveAlongZAxis : MonoBehaviour
{
    public SpeedData speedData;

    public void Update()
    {
        transform.position += new Vector3(0, 0, speedData.speed) * Time.deltaTime;
    }

    public void IncreaseSpeed(float amount)
    {
        speedData.speed += amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

   
}