using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    // The spawn point where the player should be reset to
    public Vector3 spawnPoint = new Vector3(461f, 46f, 1153f);  // Default coordinates (461, 46, 1153)

    public float fallThreshold = -2f;  // Height below which the player is considered to have fallen off

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // You can optionally ensure spawnPoint is set here, though it's already done above
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player's position is below the fall threshold (e.g., falling off the map)
        if (transform.position.y < fallThreshold)
        {
            TeleportToSpawnPoint();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If the player hits the floor, teleport back to the spawn point
        if (other.gameObject.CompareTag("Floor"))
        {
            TeleportToSpawnPoint();
        }
    }

    private void TeleportToSpawnPoint()
    {
        // Reset position to the spawn point
        //transform.position = spawnPoint;
        transform.SetPositionAndRotation(spawnPoint, Quaternion.identity);

        // No need for Rigidbody velocity reset as we're not using Rigidbody
        Debug.Log("Player has been reset to spawn point.");
    }
}