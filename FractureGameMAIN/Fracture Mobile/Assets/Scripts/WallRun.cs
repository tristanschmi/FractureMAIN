using UnityEngine;

public class WallRun : MonoBehaviour
{
    public float jumpForce = 10f;
    public float leftXCoordinate = -5f;
    public float rightXCoordinate = 5f;
    private Rigidbody rb;
    private Vector2 startTouchPosition, endTouchPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                Vector2 swipeDirection = endTouchPosition - startTouchPosition;

                if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                {
                    if (swipeDirection.x > 0)
                    {
                        JumpToPosition(rightXCoordinate);
                    }
                    else
                    {
                        JumpToPosition(leftXCoordinate);
                    }
                }
            }
        }
    }

    private void JumpToPosition(float xCoordinate)
    {
        rb.linearVelocity = new Vector2(0, jumpForce);
        transform.position = new Vector3(xCoordinate, transform.position.y, transform.position.z);
    }
}