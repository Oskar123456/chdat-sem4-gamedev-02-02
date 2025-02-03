using UnityEngine;
using UnityEngine.AI;

public class ChessPlayer : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private EnemyHealth enemyHealth;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform; 
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); 
        }

        // Påfør skade ved klik
        if (Input.GetMouseButtonDown(0))
        {
            Camera playerCamera = GameObject.Find("PlayerCamera")?.GetComponent<Camera>();
            if (playerCamera != null)
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log("Raycast ramte: " + hit.collider.gameObject.name); // Debug

                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Fjenden blev ramt!"); // Debug
                        enemyHealth.TakeDamage(20); 
                    }
                }
            }
        }
    }
}


