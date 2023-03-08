using UnityEngine;

public class Player : MonoBehaviour
{
    private const float force = 8.0f;

    private const float normalGravity = 3.0f;
    private const float fallGravity = 4.0f;

    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.gravityScale = Rigidbody.velocity.y > 0 ? normalGravity : fallGravity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("gold"))
        {
            var coin = Instantiate(Resources.Load<Coin>("coin"));
            coin.transform.position = collision.transform.position;

            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("platform"))
        {
            Debug.Log("game over");
        }
    }
}
