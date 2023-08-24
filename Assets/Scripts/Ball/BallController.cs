using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform shooterLocation;
    [SerializeField] private float returnSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }
    private void FixedUpdate()
    {
        if(rb.velocity.y == 0 && !isGrounded)
        {
            rb.AddForce(Vector2.up);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero;
            Vector3 direction = (shooterLocation.position - transform.position).normalized;
            direction.y = 0;
            rb.AddForce(direction * returnSpeed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ShooterController>() != null)
        {
            ShooterController shooter = collision.GetComponent<ShooterController>();
            shooter.IncreaseBalls();
            Destroy(gameObject);
        }
    }
}
