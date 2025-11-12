using UnityEngine;

public class Ataque : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Bandido bandido = other.GetComponent<Bandido>();
            if (bandido != null)
            {
                bandido.Morir();
            }

            Destroy(gameObject);
        }
    }
}