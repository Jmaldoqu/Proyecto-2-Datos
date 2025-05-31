using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;


public class BTree1 : Tree
{
    private int M;
    public BTreeNode root;

    public BTree1(int t)
    {
        M = 2 * t;
    }

    private BTreeNode CreateNode(bool isLeaf)
    {
        return new BTreeNode(isLeaf, M);
    }

    private void SplitChild(BTreeNode parent, int index)
    {
        BTreeNode child = parent.children[index];
        BTreeNode newNode = CreateNode(child.IsLeaf);

        int t = M / 2;

        for (int i = 0; i < t - 1; i++)
        {
            newNode.keys[i] = child.keys[i + t];
        }

        if (!child.IsLeaf)
        {
            for (int i = 0; i < t; i++)
            {
                newNode.children[i] = child.children[i + t];
            }
        }

        int middleKey = child.keys[t - 1];

        newNode.NumKeys = t - 1;
        child.NumKeys = t - 1;

        for (int i = parent.NumKeys; i > index; i--)
        {
            parent.children[i + 1] = parent.children[i];
        }
        parent.children[index + 1] = newNode;

        for (int i = parent.NumKeys - 1; i >= index; i--)
        {
            parent.keys[i + 1] = parent.keys[i];
        }
        parent.keys[index] = middleKey;
        parent.NumKeys++;
    }

    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.NumKeys - 1;

        if (node.IsLeaf)
        {
            while (i >= 0 && node.keys[i] > key)
            {
                node.keys[i + 1] = node.keys[i];
                i--;
            }

            node.keys[i + 1] = key;
            node.NumKeys++;
        }
        else
        {
            while (i >= 0 && node.keys[i] > key)
            {
                i--;
            }
            i++;

            if (node.children[i].NumKeys == M - 1)
            {
                SplitChild(node, i);

                if (node.keys[i] < key)
                {
                    i++;
                }
            }
            InsertNonFull(node.children[i], key);
        }
    }

    public override void Insert(int key)
    {
        if (root == null)
        {
            root = CreateNode(true);
            root.keys[0] = key;
            root.NumKeys = 1;
        }
        else
        {
            if (root.NumKeys == M - 1)
            {
                BTreeNode newRoot = CreateNode(false);
                newRoot.children[0] = root;
                SplitChild(newRoot, 0);
                root = newRoot;
            }
            InsertNonFull(root, key);
        }
    }


    public void Traverse()
    {
        Traverse(root);
        Console.WriteLine();
    }

    private void Traverse(BTreeNode node)
    {
        if (node != null)
        {
            int i;
            for (i = 0; i < node.NumKeys; i++)
            {
                Traverse(node.children[i]);
                Console.Write(node.keys[i] + " ");
            }
            Traverse(node.children[i]);
        }
    }




    public override string[] getNodesForVisuals(int challengeOption)

    {
        var result = new List<int>();

        if (root == null)
        {

            string[] emptyResult = new string[15];
            for (int i = 0; i < 15; i++)
            {
                emptyResult[i] = "0";
            }
            return emptyResult;
        }

        Queue<BTreeNode> queue = new Queue<BTreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            BTreeNode node = queue.Dequeue();


            for (int i = 0; i < 3; i++)
            {
                if (i < node.NumKeys)
                {
                    result.Add(node.keys[i]);
                }
                else
                {
                    result.Add(0);
                }
            }


            if (!node.IsLeaf)
            {
                for (int i = 0; i <= node.NumKeys; i++)
                {
                    if (node.children[i] != null)
                    {
                        queue.Enqueue(node.children[i]);
                    }
                }
            }
        }


        while (result.Count < 15)
        {
            result.Add(0);
        }

        if (result.Count > 15)
        {
            result = result.Take(15).ToList();
        }


        string[] finalResult = new string[15];
        for (int i = 0; i < 15; i++)
        {
            finalResult[i] = result[i].ToString();
        }

        return finalResult;
    }



    public override bool Search(int key)
    {
        return SearchRecursive(root, key);
    }

    private bool SearchRecursive(BTreeNode node, int key)
    {
        if (node == null)
        {
            return false;
        }

        int i = 0;


        while (i < node.NumKeys && key > node.keys[i])
        {
            i++;
        }


        if (i < node.NumKeys && key == node.keys[i])
        {
            return true;
        }


        if (node.IsLeaf)
        {
            return false;
        }

        return SearchRecursive(node.children[i], key);
    }


    public override int GetDepth()
    {
        int depth = 0;
        BTreeNode node = root;

        while (node != null)
        {
            depth++;
            node = node.children[0];

        }


        string[] x = getNodesForVisuals(2);

        if (x.Length == 3)
        {
            return 0;
        }

        else
        {

            if (x[3] != "0" && x[4] != "0" && x[5] != "0")
            {
                return 1;
            }
            else if (x[6] != "0" && x[7] != "0" && x[9] != "0")
            {
                return 1;
            }
            else if (x[9] != "0" && x[10] != "0" && x[11] != "0")
            {
                return 1;
            }
            else if (x[12] != "0" && x[13] != "0" && x[14] != "0")
            {
                return 1;
            }
            else
            {
                return 0;
            }


        }

    }


    public override void Clear()
    {
        root = null;
    }
}

