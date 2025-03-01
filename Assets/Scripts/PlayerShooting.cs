using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootSound;

    public ProjectileBehavior projectilePrefab;
    public Transform LaunchOffset;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play shooting sound
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // instantiate bullets
        Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
    }
}

