using UnityEngine;
using System.Collections;

public class CofreFinal : MonoBehaviour
{
    public GameObject Panel;
    public float tiempoAnimacionApertura = 1.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;

            if (animator != null)
            {
                animator.SetTrigger("Open");
            }

            StartCoroutine(MostrarVictoriaConRetraso());
        }
    }

    private IEnumerator MostrarVictoriaConRetraso()
    {
        yield return new WaitForSeconds(tiempoAnimacionApertura);

        if (Panel != null)
        {
            Panel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}