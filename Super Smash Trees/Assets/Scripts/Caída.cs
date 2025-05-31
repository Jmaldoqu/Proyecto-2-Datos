using UnityEngine;

public class FallReset : MonoBehaviour
{
    public float fallThreshold = -10f;
    private Vector3 initialPosition;

    [Header("Jugador al que se le suman puntos")]
    public GameObject otroJugador; // El otro jugador que se beneficia
    public int puntosBonus = 5;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            ResetPosition();
            DarPuntosAlOtro();
        }
    }

    void ResetPosition()
    {
        transform.position = initialPosition;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    void DarPuntosAlOtro()
    {
        if (otroJugador != null)
        {
            PlayerScore score = otroJugador.GetComponent<PlayerScore>();
            if (score != null)
            {
                score.AddPoints(puntosBonus);
                Debug.Log(otroJugador.name + " gana " + puntosBonus + " puntos porque el otro cayó");
            }
        }
    }
}