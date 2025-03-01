using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    public AudioSource audioSource;
    public AudioClip powerupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(powerupSound);
        Destroy(gameObject, 0.7f);
        powerupEffect.Apply(collision.gameObject);
    }
}
