using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float groundSpeed = 5f;
    public float jumpSpeed = 8f;
    public float direction = 0f;
    public bool isFacingRight;

    public Animator animator;

    //ground check
    public bool grounded;
    public Transform groundCheck;
    public LayerMask groundMask;

    public CrystalManager cm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        direction = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(direction));
        animator.SetBool("IsOnGround", grounded);

        if (direction > 0f)
        {
            body.linearVelocity = new Vector2(direction * groundSpeed, body.linearVelocity.y);
        }
        else if (direction < 0f)
        {
            body.linearVelocity = new Vector2(direction * groundSpeed, body.linearVelocity.y);
        }
        else
        {
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpSpeed);
        }

        // flip player
        if (!isFacingRight && direction > 0f)
        {
            Flip();
        }
        else if (isFacingRight  && direction < 0f)
        {
            Flip();
        }

        //GetInput();

        //if (Mathf.Abs(xInput) > 0)
        //{
        //    body.linearVelocity = new Vector2(xInput * groundSpeed, body.linearVelocity.y);
        //}

        //if (Mathf.Abs(yInput) > 0 && grounded)
        //{
        //    body.linearVelocity = new Vector2(body.linearVelocity.x, yInput * jumpSpeed);
        //}
    }

    //void FixedUpdate()
    //{
    //    CheckGround();
    //    if(grounded && xInput == 0 && yInput == 0)
    //    {
    //        body.linearVelocity *= groundDecay;
    //    }
    //}

    //void GetInput()
    //{
    //    xInput = Input.GetAxis("Horizontal");
    //    yInput = Input.GetAxis("Vertical");
    //}

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);
    }

    // Trigger for CRYSTALS
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
            cm.crystalCount++;
            Debug.Log("Crystal hit!");
        }
    }
}
