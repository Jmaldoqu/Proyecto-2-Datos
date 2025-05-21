using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 155f;
   	public KeyCode attackKey = KeyCode.Space; // Key for attack
    public float attackRange = 1f; // Range for attack
    
	public float attackCooldown = 2f; // Cooldown for attack
	public float pushForce = 10f; // Force applied to the attacked object
	public float animationTime = 2.9f; // Time for attack animation
	
    private Rigidbody2D rb; // Rigidbody for physics
    private Animator anim; // Animator for animations
    private float horizontal; // Horizontal movement input
    private bool isGrounded; // Check if the character is on the ground
    private float DelayAttackCooldown = 0f; // Cooldown for attack
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        anim.SetBool("Running", horizontal != 0); // Set running animation based on input
        Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red); // Visualize raycast for ground check
        
		// Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector3.down, 0.7f);
        
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 1); // Flip character to the left
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 1); // Flip character to the right
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump(); // Call jump function
        }
        else if (Input.GetKeyDown(attackKey) && Time.time >= DelayAttackCooldown) // Check if attack key is pressed and cooldown is over
        { 

		  DelayAttackCooldown = Time.time + attackCooldown; // Set cooldown time
	      Attack(); // Call attack function
		  
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce)); // Apply force for jump
    }   
	private void Attack()
	{
		anim.SetBool("Attack", true);
    	speed = 0;
		StartCoroutine(AttackRayCastDelay()); // Start coroutine for attack delay
	}
	private IEnumerator AttackRayCastDelay()
	{	
		yield return new WaitForSeconds(animationTime);	
		Vector2 attackDirection = new Vector2(transform.localScale.x, 0); // Get attack direction based on character scale
		Debug.DrawRay(transform.position, attackDirection * attackRange, Color.red); // Visualize attack direction
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, 1f); // Raycast to check for objects in front of the character
		if (hit.collider != null)
		{
			Debug.Log("Hit: " + hit.collider.name); // Log the name of the hit object

			PlayerMovement otherPlayer = hit.collider.GetComponent<PlayerMovement>(); // Get PlayerMovement component of the hit object
			if (otherPlayer != null)
			{
				otherPlayer.RecibirAtaque(pushForce); // Call method to apply knockback
			}
		}
		
		anim.SetBool("Attack", false); // Reset attack animation
		speed = 5f; // Reset speed
	}
	public void RecibirAtaque(float knockback)
	{
		Debug.Log("Recibiendo ataque en dirección: " + knockback);
		// Aquí puedes implementar la lógica para recibir el ataque, por ejemplo, aplicar un empuje:
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			Debug.Log("El personaje si tiene rb");
			rb.AddForce(new Vector2(horizontal + knockback, jumpForce)); // Apply force to the character
		}
	}

}	

    

