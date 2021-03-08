using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Transform patrol;
    
    private bool isFacingRight = false;
    private RaycastHit2D hit;

    private void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        hit = Physics2D.Raycast(patrol.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate()
    {
        if (hit.collider)
        {
            //Debug.Log("hitting ground");
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            //Debug.Log("not hitting ground");
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 2f, 1f);
        }
    }
}
