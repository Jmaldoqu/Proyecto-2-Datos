using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float speed = 5.0f;

    public Challenge challenge;
    public string TreeChallengeType;
    public Tree arbol;

    private void Start()
    {
        StartCoroutine(WaitForChallenge());
    }

    private IEnumerator WaitForChallenge()
    {
        // Busca challenge en el padre si no fue asignado
        if (challenge == null)
        {
            challenge = GetComponentInParent<Challenge>();
        }

        // Espera hasta que challenge y su árbol estén listos
        while (challenge == null || challenge.ChallengeTree == null)
        {
            yield return null; // Espera 1 frame
        }

        TreeChallengeType = challenge.TreeType;
        arbol = challenge.ChallengeTree;

        Debug.Log("Árbol cargado correctamente: " + TreeChallengeType);
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (arbol == null || challenge == null) return;

        // BST
        if (TreeChallengeType == "BST" && collision.CompareTag("BSTTokenTag"))
        {
            BSTToken token = collision.GetComponent<BSTToken>();
            if (token != null && !arbol.Search(token.value))
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }

        // AVL
        else if (TreeChallengeType == "AVL" && collision.CompareTag("AVLTokenTag"))
        {
            AVLToken token = collision.GetComponent<AVLToken>();
            if (token != null && !arbol.Search(token.value))
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }

        // B
        else if (TreeChallengeType == "B" && collision.CompareTag("BTokenTag"))
        {
            BToken token = collision.GetComponent<BToken>();
            if (token != null && !arbol.Search(token.value))
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }
    }
}
