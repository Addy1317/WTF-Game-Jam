using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float resetPositionX = -10f;
    [SerializeField] private float startPositionX = 10f;

    private void Update()
    {
        // Move the cloud to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Reset the position if the cloud moves off screen
        if (transform.position.x <= resetPositionX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }
}
