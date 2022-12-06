using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Transform GroundCheck;

    public float collisionRadius;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool onGround;
    private SpriteRenderer sr;

    public CapsuleCollider2D Collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Collider.enabled = true;
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)GroundCheck.position, collisionRadius, groundMask);

        float x = Input.GetAxis("Horizontal") * speed;
        Vector2 dir = new Vector2(x, rb.velocity.y);

        Move(dir);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump(Vector2.up);
        }
    }

    private void Move(Vector2 dir)
    {
        if (rb.velocity.x > 0)
            sr.flipX = false;
        else if (rb.velocity.x < 0)
            sr.flipX = true;

        rb.velocity = dir;
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.velocity += dir * jumpForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, collisionRadius);
    }
}