using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class BTree1 : Tree
{
    public BTreeNode root;
    private int t = 3; // Orden mínimo

    public override bool Search(int key)
    {
        return root != null && root.Search(key);
    }

    public override void Insert(int key)
    {
        if (root == null)
        {
            root = new BTreeNode(t, true);
            root.keys.Add(key);
        }
        else
        {
            if (root.keys.Count == 2 * t - 1)
            {
                BTreeNode newRoot = new BTreeNode(t, false);
                newRoot.children.Add(root);
                newRoot.SplitChild(0, root);
                int i = (newRoot.keys[0] < key) ? 1 : 0;
                newRoot.children[i].InsertNonFull(key);
                root = newRoot;
            }
            else
            {
                root.InsertNonFull(key);
            }
        }
    }

    public override int GetDepth()
    {
        return GetDepthRecursive(root);
    }

    private int GetDepthRecursive(BTreeNode node)
    {
        if (node == null) return 0;

        if (node.isLeaf) return 1;

        // BTree es balanceado, basta con seguir el primer hijo
        return 1 + GetDepthRecursive(node.children[0]);
    }

}

