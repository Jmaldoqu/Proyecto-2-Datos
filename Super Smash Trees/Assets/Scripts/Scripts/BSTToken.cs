using UnityEngine;
using TMPro;

public class BSTToken : MonoBehaviour {

    public int value; 
    public TextMeshPro txt;
    public string type = "BST";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = Random.Range(0, 50);
        txt.text = value.ToString();

        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
