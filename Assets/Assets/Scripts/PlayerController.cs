using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	BoxCollider2D collider;
	float distToGround;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
				collider = GetComponent<BoxCollider2D>();
				distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}