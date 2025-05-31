using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public Challenge_2 challenge;
    public string TreeChallengeType;
    public Tree arbol;

    public float speed = 5f;
    public float jumpForce = 155f;
    public KeyCode attackKey = KeyCode.Space;
    public KeyCode ShieldKey = KeyCode.LeftShift;

    // Teclas configurables desde el Inspector
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public float pushForce = 10f;
    public float animationTime = 2.9f;

    private bool ExtraJump = false;
    private bool ExtraShield = false;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    private bool isGrounded;
    private float DelayAttackCooldown = 0f;
    private bool shielded = false;

    public int PoderActivado;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(WaitForChallenge());
    }

    void Update()
    {
        // Movimiento horizontal con teclas configurables
        if (Input.GetKey(moveLeftKey))
            horizontal = -1;
        else if (Input.GetKey(moveRightKey))
            horizontal = 1;
        else
            horizontal = 0;

        anim.SetBool("Running", horizontal != 0);

        Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red);
        isGrounded = Physics2D.Raycast(transform.position, Vector3.down, 0.7f);

        if (horizontal < 0)
            transform.localScale = new Vector3(-3.5f, 3.5f, 1);
        else if (horizontal > 0)
            transform.localScale = new Vector3(3.5f, 3.5f, 1);

        // Saltar con tecla configurable
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(jumpKey) && ExtraJump == true)
        {
            Jump();
        }

        // Ataque
        else if (Input.GetKeyDown(attackKey) && Time.time >= DelayAttackCooldown)
        {
            DelayAttackCooldown = Time.time + attackCooldown;
            Attack();
        }

        // Escudo
        if (Input.GetKeyDown(ShieldKey) && ExtraShield == true)
        {
            shielded = true;
            anim.SetBool("Shield", true);
        }
        if (Input.GetKeyUp(ShieldKey))
        {
            shielded = false;
            anim.SetBool("Shield", false);
        }
    }

    public void GetPowers() {

        PoderActivado = challenge.powerUp;

        if (PoderActivado == 1) { ExtraShield = true; }
        else if (PoderActivado == 2) { ExtraShield = true; }
        else if (PoderActivado == 3) { ExtraJump = true; } //Push?
        else if (PoderActivado == 4) { ExtraJump = true; }
        else if (PoderActivado == 5) { ExtraJump = true; }
        else if (PoderActivado == 6) { ExtraJump = true; }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void Attack()
    {
        anim.SetBool("Attack", true);
        speed = 0;
        StartCoroutine(AttackRayCastDelay());
    }

    private IEnumerator AttackRayCastDelay()
    {
        yield return new WaitForSeconds(animationTime);

        Vector2 attackDirection = new Vector2(transform.localScale.x, 0);
        Debug.DrawRay(transform.position, attackDirection * attackRange, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection, attackRange);
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);

            PlayerMovement otherPlayer = hit.collider.GetComponent<PlayerMovement>();
            if (otherPlayer != null)
            {
                otherPlayer.RecibirAtaque(pushForce);
            }
        }

        anim.SetBool("Attack", false);
        speed = 5f;
    }

    private IEnumerator WaitForChallenge()
    {
       
        if (challenge == null)
        {
            challenge = GetComponentInParent<Challenge_2>();
        }

       
        while (challenge == null || challenge.ChallengeTree == null)
        {
            yield return null; // Espera 1 frame
        }

        TreeChallengeType = challenge.TreeType;
        arbol = challenge.ChallengeTree;

        Debug.Log("Árbol cargado correctamente: " + TreeChallengeType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (arbol == null || challenge == null) { Debug.Log("ver si es null"); }

        // BST
        if (TreeChallengeType == "BST" && collision.CompareTag("BSTTokenTag"))
        {
            BSTToken token = collision.GetComponent<BSTToken>();
            if (token != null && !arbol.Search(token.value))
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }

        // AVL
        else if (TreeChallengeType == "AVL" && collision.CompareTag("AVLTokenTag"))
        {
            AVLToken token = collision.GetComponent<AVLToken>();
            if (token != null && !arbol.Search(token.value))
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }

        // B
        else if (TreeChallengeType == "B" && collision.CompareTag("BTokenTag"))
        {
            int BChallengeTyppe = challenge.challengeOption;
            BToken token = collision.GetComponent<BToken>();

            if (BChallengeTyppe == 0 && token.value < 70 && token != null && !arbol.Search(token.value))
            { //Challege 1 - llenarlo con menores de 70

                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
            else if (BChallengeTyppe == 1 && token.value >= 70 && token != null && !arbol.Search(token.value)) //Challenge 2 - llenarlo con mayores o iguales a 70
            {
                challenge.InsertInTree(token.value);
                Destroy(collision.gameObject);
            }
        }
    }


    public void RecibirAtaque(float knockback)
    {
        Debug.Log("Recibiendo ataque en dirección: " + knockback);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null && !shielded)
        {
            Debug.Log("El personaje sí tiene rb");
            rb.AddForce(new Vector2(horizontal + knockback, jumpForce));
        }
        else
        {
            Debug.Log("Está protegido por el escudo");
        }
    }
}
	

    

