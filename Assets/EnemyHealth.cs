using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthBar; // Reference til UI Health Bar

    private Camera playerCamera;

    void Start()
    {
        currentHealth = maxHealth;
        playerCamera = GameObject.Find("PlayerCamera")?.GetComponent<Camera>(); // Henter PlayerCamera
        UpdateHealthBar();
    }

    void Update()
    {
        if (healthBar != null && playerCamera != null)
        {
            // Følg fjendens position i skærmrummet baseret på PlayerCamera
            Vector3 screenPosition = playerCamera.WorldToScreenPoint(transform.position + new Vector3(0, 2.5f, 0));
            healthBar.transform.position = screenPosition;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(true); // Sikrer, at HealthBar altid er synlig
            healthBar.value = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(healthBar.gameObject); // Fjern HealthBar ved død
        Destroy(gameObject);           // Fjern fjenden ved død
    }
}


