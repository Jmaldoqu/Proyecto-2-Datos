using UnityEngine;

public class Knightmovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 155f;
    private Rigidbody2D rb;
    private Animator anim;
    private float Horizontal;
    private bool Grounded;

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

        if (Horizontal < 0)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 1);
        }

        else if (Horizontal > 0) {
            transform.localScale = new Vector3(3.5f, 3.5f, 1);
        }

        anim.SetBool("Running", Horizontal != 0); //Si Horizontal es diferente de 0, entonces el personaje está corriendo
        Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.7f))
        {
            Grounded = true;
        }
        else Grounded = false;

        anim.SetBool("Jumping", !Grounded);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {  
            Jump();
        }


    }
    
    private void FixedUpdate() //Esto es para que las físicas no dependan de la cantidad de frames a las que vaya el juego
    {  
        rb.linearVelocity = new Vector2(Horizontal * speed, rb.linearVelocity.y); //rb.velocity es la velocidad del rigidbody
    }
    
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }   
}

