using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Rendering;
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

    public override void Clear() { 
        root = null;
    }
    public override string[] getNodesForVisuals(int challengeOption) {

        int[] list = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        if (root == null)
        {
            string[] temp1 = new string[15];

            for (int i = 0; i < list.Length; i++)
            {

                temp1[i] = list[i].ToString();

            }

            return temp1;
        }

        else
        {
            list[0] = root.key;

            if (root.left != null)
            {
                list[1] = root.left.key;
                BSTTreeNode temp = root.left;

                if (temp.left != null) {
                    list[3] = temp.left.key;

                    if (temp.left.left != null)
                    {
                        list[7] = temp.left.left.key;
                    }

                    if (temp.left.right != null)
                    {
                        list[8] = temp.left.right.key;
                    }
                }

                if (temp.right != null) {
                    list[4] = temp.right.key;

                    if (temp.right.left != null)
                    {
                        list[9] = temp.right.left.key;
                    }

                    if (temp.right.right != null) {
                        list[10] = temp.right.right.key;
                    }
                }
            }

            if (root.right != null)
            {

                list[2] = root.right.key;
                BSTTreeNode temp = root.right;

                if (temp.left != null)
                {
                    list[5] = temp.left.key;

                    if (temp.left.left != null)
                    {

                        list[11] = temp.left.left.key;

                    }

                    if (temp.left.right != null)
                    {
                        list[12] = temp.left.right.key;
                    }
                }

                if (temp.right != null)
                {

                    list[6] = temp.right.key;

                    if (temp.right.left != null)
                    {
                        list[13] = temp.right.left.key;
                    }


                    if (temp.right.right != null)
                    {
                        list[14] = temp.right.right.key;
                    }
                }
            }

            string[] temp1 = new string[15];

            for (int i = 0; i < list.Length; i++)
            {

                temp1[i] = list[i].ToString();

            }

            return temp1;


        }   }


}
