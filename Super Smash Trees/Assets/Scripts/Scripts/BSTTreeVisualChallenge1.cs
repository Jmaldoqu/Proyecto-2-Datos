using UnityEngine;
using UnityEngine.UI;

public class BSTTreeVisualChallenge1 : MonoBehaviour {

    public GameObject[] Nodes;
    public GameObject Body;

    public void NodesVisualActualization(int elementosActivos, int[] valoresInOrder)
    {
        Debug.Log(elementosActivos);
        Debug.Log(valoresInOrder);

        SpriteRenderer nodeRenderer = Nodes[0].GetComponent<SpriteRenderer>();

        Color blackOpaque = Color.black;
        blackOpaque.a = 1; // asegurarse de que no siga transparente
        nodeRenderer.color = blackOpaque;
    }

    public void TransparentNodes() {

        for (int i = 0; i < Nodes.Length; i = i + 1)
        {
            SpriteRenderer nodeRenderer = Nodes[i].GetComponent<SpriteRenderer>();

            Color currentColor = nodeRenderer.color;
            currentColor.a = 0f;
            nodeRenderer.color = currentColor;

        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}
}
