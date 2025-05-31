using UnityEngine;

public class AVLTree1 : Tree
{
    public AVLTreeNode root;

    public override bool Search(int key)
    {
        return SearchRecursive(root, key);
    }

    private bool SearchRecursive(AVLTreeNode node, int key)
    {
        if (node == null) return false;
        if (key == node.key) return true;
        if (key < node.key) return SearchRecursive(node.left, key);
        return SearchRecursive(node.right, key);
    }

    public override void Insert(int key)
    {
        root = InsertRecursive(root, key);
    }

    private int Height(AVLTreeNode node) => node == null ? 0 : node.height;

    private int GetBalance(AVLTreeNode node)
    {
        if (node == null) return 0;
        return Height(node.left) - Height(node.right);
    }

    private AVLTreeNode InsertRecursive(AVLTreeNode node, int key)
    {
        if (node == null)
            return new AVLTreeNode(key);

        if (key < node.key)
            node.left = InsertRecursive(node.left, key);
        else if (key > node.key)
            node.right = InsertRecursive(node.right, key);
        else
            return node; // Duplicate not allowed

        // Update height
        node.height = 1 + Mathf.Max(Height(node.left), Height(node.right));

        // Balance the tree
        int balance = GetBalance(node);

        // Left Left Case
        if (balance > 1 && key < node.left.key)
            return RotateRight(node);

        // Right Right Case
        if (balance < -1 && key > node.right.key)
            return RotateLeft(node);

        // Left Right Case
        if (balance > 1 && key > node.left.key)
        {
            node.left = RotateLeft(node.left);
            return RotateRight(node);
        }

        // Right Left Case
        if (balance < -1 && key < node.right.key)
        {
            node.right = RotateRight(node.right);
            return RotateLeft(node);
        }

        return node;
    }

    private AVLTreeNode RotateLeft(AVLTreeNode x)
    {
        AVLTreeNode y = x.right;
        AVLTreeNode T2 = y.left;

        y.left = x;
        x.right = T2;

        x.height = 1 + Mathf.Max(Height(x.left), Height(x.right));
        y.height = 1 + Mathf.Max(Height(y.left), Height(y.right));

        return y;
    }

    private AVLTreeNode RotateRight(AVLTreeNode y)
    {
        AVLTreeNode x = y.left;
        AVLTreeNode T2 = x.right;

        x.right = y;
        y.left = T2;

        y.height = 1 + Mathf.Max(Height(y.left), Height(y.right));
        x.height = 1 + Mathf.Max(Height(x.left), Height(x.right));

        return x;
    }


    public override int GetDepth()
    {
        return GetDepthRecursive(root);
    }

    private int GetDepthRecursive(AVLTreeNode node)
    {
        if (node == null) return 0;

        int left = GetDepthRecursive(node.left);
        int right = GetDepthRecursive(node.right);

        return 1 + Mathf.Max(left, right);
    }



}
