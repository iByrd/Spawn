using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthBar;

    public AudioSource audioSource;
    public AudioClip playerHurtSound;
    public AudioClip playerDeathSound;

    public GameOverManager gameOverManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (audioSource != null && playerHurtSound != null)
        {
            audioSource.PlayOneShot(playerHurtSound);
        }

        if (health <= 0)
        {
            if (audioSource != null && playerDeathSound != null)
            {
                audioSource.PlayOneShot(playerDeathSound);
            }
            gameOverManager.ShowGameOverScreen();
            gameObject.SetActive(false);
            //Destroy(gameObject, 2.0f);
        }
    }

    
}
