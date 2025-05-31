using UnityEngine;

public class AttackZoneScript : MonoBehaviour
{   
    public float damage = 10f; // Damage dealt to enemies
    public float speed = 10f;
    private Rigidbody2D rb; // Rigidbody for physics
    private Vector2 direction; // Direction of the attack zone
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    rb =  GetComponent<Rigidbody2D>();  
    }

    
    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed; // Move the attack zone
        
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir; // Set the direction of the attack zone
        
    }
}
