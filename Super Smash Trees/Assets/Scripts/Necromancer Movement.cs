using UnityEngine;

public class NecromancerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 155f;
    private Rigidbody2D rb;
    private Animator anim;
    private float Horizontal;
    private bool Grounded;
    private float nextAttackTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal < 0) transform.localScale = new Vector3(-3.5f, 3.5f, 1);
        else if (Horizontal > 0) transform.localScale = new Vector3(3.5f, 3.5f, 1);
        anim.SetBool("Walking", Horizontal != 0); //Si Horizontal es diferente de 0, entonces el personaje está corriendo
        
        Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.7f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // o el botón que quieras
            {
                
                Attack();
                speed = 5f;
            }
            else anim.SetBool("Attack", false);
        }
        
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void Attack()
    {
        anim.SetBool("Attack", true);
        speed = 0;
        nextAttackTime = Time.time + 2f;
        Debug.Log("Attack is over");
    }

    private void FixedUpdate() //Esto es para que las físicas no dependan de la cantidad de frames a las que vaya el juego
    {
       
        rb.linearVelocity = new Vector2(Horizontal * speed, rb.linearVelocity.y); //rb.velocity es la velocidad del rigidbody
    }
}
