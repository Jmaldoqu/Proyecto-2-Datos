using UnityEngine;

public class BSTTree1: Tree {

    public BSTTreeNode root;

    public override bool Search(int key) {
        return SearchRecursive(root, key);
    }

    public bool SearchRecursive(BSTTreeNode root, int key) {

        if (root == null) {

            return false;
        }
        if (key == root.key) {
            return true;
        }
        else if (key > root.key) {
            return SearchRecursive(root.right, key);
        }
        else {
            return SearchRecursive(root.left, key);
        }
    }

    public override void Insert(int key) {
        root = InsertRecursive(root, key);
    }

    public BSTTreeNode InsertRecursive(BSTTreeNode root, int key) {

        if (root == null) {
            root = new BSTTreeNode(key);
            return root;
        }
        if (key < root.key) {
            root.left = InsertRecursive(root.left, key);
        }
        else if (key > root.key) {
            root.right = InsertRecursive(root.right, key);
        }

        return root;

    }

    public override int GetDepth()
    {
        return GetDepthRecursive(root);
    }

    private int GetDepthRecursive(BSTTreeNode node)
    {
        if (node == null) return 0;

        int left = GetDepthRecursive(node.left);
        int right = GetDepthRecursive(node.right);

        return 1 + Mathf.Max(left, right);
    }


}
