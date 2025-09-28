using UnityEngine;

public class ScollingObject : MonoBehaviour
{   
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(GameManager.instance.currentScrollSpeed, 0);
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = new Vector2(GameManager.instance.currentScrollSpeed, 0);
        }
    }
}
