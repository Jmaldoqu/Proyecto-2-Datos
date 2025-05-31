using UnityEngine;
using TMPro;

public class BSTTreeVisualChallenge1 : MonoBehaviour
{
    public GameObject[] Nodes;

    public void NodesVisualActualization(int elementosActivos, string[] valoresInOrder)
    {
        Debug.Log($"Valores InOrder: {string.Join(", ", valoresInOrder)}");
        
        for (int i = 0; i < 15; i++)
        {
           
            if (valoresInOrder[i] != "-1")
            {
                SpriteRenderer nodeRenderer = Nodes[i].GetComponent<SpriteRenderer>();
                Color currentColor = new Color32(0x49, 0x15, 0xEA, 0xFF);
                nodeRenderer.color = currentColor;

                TextMeshPro txtValue = Nodes[i].GetComponentInChildren<TextMeshPro>();
                if (txtValue != null)
                    txtValue.SetText(valoresInOrder[i]);
            }
        }
    }

    public void TransparentNodes()
    {
        for (int i = 0; i < Nodes.Length; i++)
        {

            SpriteRenderer nodeRenderer = Nodes[i].GetComponent<SpriteRenderer>();

            Color currentColor = nodeRenderer.color;
            currentColor.a = 0f;
            nodeRenderer.color = currentColor;

            TextMeshPro txtValue = Nodes[i].GetComponentInChildren<TextMeshPro>();
            if (txtValue != null)
                txtValue.SetText(" ");
        }
    }
}
