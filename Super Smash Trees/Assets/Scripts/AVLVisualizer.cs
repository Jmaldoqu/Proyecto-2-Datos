using System.Collections.Generic;
using UnityEngine;

public class AVLVisualizer : MonoBehaviour
{
    [System.Serializable]
    public class Node
    {
        public int value;
        public Node left, right;
        public int height;
        public Vector3 position;
    }

    public Node root;
    public GameObject nodePrefab; // Prefab con una esfera o círculo
    public Material lineMaterial;
    public float xSpacing = 2f;
    public float ySpacing = 2f;

    void Start()
    {
        // Ejemplo de árbol AVL (puedes reemplazar con uno dinámico)
        root = new Node { value = 10 };
        root.left = new Node { value = 5 };
        root.right = new Node { value = 15 };
        root.left.left = new Node { value = 2 };
        root.left.right = new Node { value = 7 };
        root.right.right = new Node { value = 20 };

        AssignPositions(root, 0, 0);
        DrawTree(root);
    }

    void AssignPositions(Node node, int depth, float xOffset)
    {
        if (node == null) return;

        float xPos = xOffset;
        if (node.left != null)
            AssignPositions(node.left, depth + 1, xOffset - xSpacing / (depth + 1));
        if (node.right != null)
            AssignPositions(node.right, depth + 1, xOffset + xSpacing / (depth + 1));

        node.position = new Vector3(xPos, -depth * ySpacing, 0);
    }

    void DrawTree(Node node)
    {
        if (node == null) return;

        GameObject sphere = Instantiate(nodePrefab, node.position, Quaternion.identity, transform);
        TextMesh text = sphere.GetComponentInChildren<TextMesh>();
        if (text != null) text.text = node.value.ToString();

        if (node.left != null)
        {
            DrawLine(node.position, node.left.position);
            DrawTree(node.left);
        }

        if (node.right != null)
        {
            DrawLine(node.position, node.right.position);
            DrawTree(node.right);
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("Line");
        lineObj.transform.parent = transform;
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.material = lineMaterial;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}
