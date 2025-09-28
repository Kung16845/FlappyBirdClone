using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 10f;
    [SerializeField] Rigidbody2D rb;
    public bool isDead;
    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            AudioManager.instance.PlaySoundEffect(Sound.Jump);
            anim.SetTrigger("Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.BirdDied();
        anim.SetTrigger("Die");
        isDead = true;
    }
    public void ResetAnim()
    {
        anim.Play("Idle");
    }
}
