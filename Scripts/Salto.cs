using System.Collections;
using UnityEngine;
using TMPro;

public class Salto : MonoBehaviour
{
    public float thrust = 10.0f;
    private Rigidbody2D rb2D;
    private bool isJumping = false;
    private Animator animator;

    public TextMeshProUGUI textoPuntuacion;
    private int puntuacionActual = 0;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ActualizarUI();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void AñadirPuntos(int puntos)
    {
        puntuacionActual += puntos;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntuacionActual;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Plataforma"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, 0f);
        }
    }
}