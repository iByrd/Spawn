using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the "Player" tag
        {
            other.GetComponent<AudioSource>().PlayOneShot(pickupSound, 1.5f);
            //AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Add logic for giving points, disabling the crystal, etc.
            //cm.crystalCount++;
            //Debug.Log("Crystal hit!");
            //Destroy(gameObject);
        }
    }
}

