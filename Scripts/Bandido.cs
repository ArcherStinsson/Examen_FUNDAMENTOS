using UnityEngine;

public class Bandido : MonoBehaviour
{
    private Animator animator;
    private Collider2D col;

    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    public void Morir()
    {
        if (animator != null)
        {
            animator.SetTrigger("Muerto");
        }

        if (col != null)
        {
            col.enabled = false;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
        }

        Destroy(gameObject,1f);
    }
}