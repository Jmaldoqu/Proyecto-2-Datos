using UnityEngine;

public class Ataque : MonoBehaviour
{
    // Daño que causará el ataque
    public int damage = 10;

    // Este método se llama cuando un objeto entra en el área del trigger (Collider).
    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}