using UnityEngine;

public class RandomPlatformActivator : MonoBehaviour
{
    void Start()
    {
        // Recorre cada hijo del objeto
        foreach (Transform child in transform)
        {
            // Decide aleatoriamente si activar o desactivar (50% de probabilidad)
            bool activate = Random.value > 0.5f;
            child.gameObject.SetActive(activate);
        }
    }
}
