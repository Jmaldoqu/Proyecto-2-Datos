using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BSTTree : MonoBehaviour
{
    public BSTTreeNode root;
    private SpriteRenderer spriteRenderer;

    public bool Search(int key) {
        return SearchRecursive(root, key);
    }

    public bool SearchRecursive(BSTTreeNode root, int key) {

        if (root == null) {

            return false;
        }
        if (key == root.key)
        {
            return true;
        }
        else if (key > root.key)
        {
            return SearchRecursive(root.right, key);
        }
        else {
            return SearchRecursive(root.left, key);
        }
    }

    public void insert(int key){
        root = InsertRecursive(root, key);
    }

    public BSTTreeNode InsertRecursive(BSTTreeNode root, int key) {

        if (root == null)
        {
            root = new BSTTreeNode(key);
            return root;
        }
        if (key < root.key)
        {
            root.left = InsertRecursive(root.left, key);
        }
        else if (key > root.key)
        {
            root.right = InsertRecursive(root.right, key);
        }

        spriteRenderer.color = new Color(
           Random.value,
           Random.value,
           Random.value);

        return root;
    }

    void OnMouseDown()
    {
        spriteRenderer.color = new Color(
            Random.value,
            Random.value,
            Random.value);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        root = null;


    }

    // Update is called once per frame
    void Update() {

        
    }
}
