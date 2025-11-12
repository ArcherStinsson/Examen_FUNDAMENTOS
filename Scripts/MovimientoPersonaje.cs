using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject prefab;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);

        if (horizontalInput != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Atacar();
        }
    }

    public void Atacar()
    {
        if (animator)
        {
            animator.SetTrigger("Attack");
        }

        if (prefab)
        {
            float direccion;

            if (spriteRenderer.flipX == true)
            {
                direccion = -1f;
            }
            else
            {
                direccion = 1f;
            }

            Vector3 offset = new Vector3(1f * direccion, 0f, 0f);
            GameObject hitbox = Instantiate(prefab, transform.position + offset, Quaternion.identity);
            Destroy(hitbox, 0.3f);
        }
    }
}