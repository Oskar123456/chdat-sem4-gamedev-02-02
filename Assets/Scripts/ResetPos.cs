using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private Vector3 startPosition; // Store the initial position

    void Start()
    {
        startPosition = transform.position; // Save the starting position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetZone")) // Ensure the trigger object has this tag
        {
            ResetObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ResetZone"))
        {
            Debug.Log("ResetZone touched! Resetting position...");
            ResetObject();
        }
    }

    private void ResetObject()
    {
        Debug.Log("Teleporting to: " + startPosition);

        gameObject.SetActive(false);
        transform.position = startPosition;
        gameObject.SetActive(true);
    }



}