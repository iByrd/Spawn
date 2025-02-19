using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed;
    public PlayerMovement playerMovement;
    public bool facingRight;
    public EnemyHealth enemyHealth;
    public float damage;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        facingRight = playerMovement.isFacingRight;
    }
    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        } else
        {
            transform.position += transform.right * Time.deltaTime * -speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            //enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
