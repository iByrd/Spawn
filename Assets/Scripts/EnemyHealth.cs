using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public AudioSource audioSource;
    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }
            Destroy(gameObject, 0.3f);
        }
    }
}
