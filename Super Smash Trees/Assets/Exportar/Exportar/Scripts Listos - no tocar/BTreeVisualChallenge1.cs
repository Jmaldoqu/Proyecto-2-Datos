using TMPro;
using UnityEngine;

public class BTreeVisualChallenge1 : MonoBehaviour
{

    public GameObject[] Nodes;

    public void NodesVisualActualization1(int elementosActivos, string[] valoresInOrder)
    {

        Debug.Log($"Valores InOrder: {string.Join(", ", valoresInOrder)}");

        for (int i = 0; i < valoresInOrder.Length; i++)
        {

            if (valoresInOrder[i] == "0")
            {

                valoresInOrder[i] = " ";
            }

        }


        string[] valuesForNodes = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        Debug.Log(valoresInOrder.Length);

        for (int i = 0; i < valoresInOrder.Length; i++)
        {
            valuesForNodes[i] = valoresInOrder[i];
        }



        for (int i = 0; i < 5; i++)
        {

            if (valuesForNodes[i] != "")
            {
                SpriteRenderer nodeRenderer = Nodes[i].GetComponent<SpriteRenderer>();
                nodeRenderer.color = Color.white;

                TextMeshPro txtValue = Nodes[i].GetComponentInChildren<TextMeshPro>();
                if (txtValue != null)
                    txtValue.SetText(valuesForNodes[i]);
            }
        }
    }


    public void NodesVisualActualization(int elementosActivos, string[] valoresInOrder)
    {
        string[] final = new string[5];

        Debug.Log(valoresInOrder.Length);

        if (valoresInOrder.Length == 3)
        {

            final[0] = valoresInOrder[0] + " - " + valoresInOrder[1] + " - " + valoresInOrder[2];
            final[1] = "  -   -  ";
            final[2] = "  -   -  ";
            final[3] = "  -   -  ";
            final[4] = "  -   -  ";


        }
        else
        {

            for (int i = 0; i < valoresInOrder.Length; i++)
            {

                if (valoresInOrder[i] == "0")
                {

                    valoresInOrder[i] = " ";
                }
            }

            final[0] = valoresInOrder[0] + " - " + valoresInOrder[1] + " - " + valoresInOrder[2];
            final[1] = valoresInOrder[3] + " - " + valoresInOrder[4] + " - " + valoresInOrder[5];
            final[2] = valoresInOrder[6] + " - " + valoresInOrder[7] + " - " + valoresInOrder[8];
            final[3] = valoresInOrder[9] + " - " + valoresInOrder[10] + " - " + valoresInOrder[11];
            final[4] = valoresInOrder[12] + " - " + valoresInOrder[13] + " - " + valoresInOrder[14];

        }


        for (int j = 0; j < 5; j++)
        {

            if (final[j] != "  -   -  ")
            {
                SpriteRenderer nodeRenderer = Nodes[j].GetComponent<SpriteRenderer>();
                nodeRenderer.color = Color.white;

                TextMeshPro txtValue = Nodes[j].GetComponentInChildren<TextMeshPro>();
                if (txtValue != null)
                    txtValue.SetText(final[j]);
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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
