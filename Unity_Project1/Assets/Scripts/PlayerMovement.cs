using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int shift_speed;
    public int jumpForce;
    public bool isJumping = false;
    public bool isGrounded = true;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool isRunning = true;
    private bool isRestarting = false;
    private bool isAttacking = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public enum States
    {
        idle,
        run,
        jump,
        die,
        Falling
    }
    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }


    void Update()
    {
        if (!isRunning)
        {
            return;
        }
        if (isGrounded) State = States.idle;
      
        if (isAttacking)
        {
            anim.Play("attack");
             return;
        }

        if(Input.GetButton("Horizontal"))
            if (isGrounded)
            {
                Run();
            }
        if (Input.GetMouseButtonUp(0))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Attack()); 
            }
        }

       
        
        float xDisplacement = Input.GetAxis("Horizontal");
        float yDisplacement = 0;
        float actualSpeed = 0;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            anim.Play("jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            actualSpeed = shift_speed;
        else
            actualSpeed = speed;

        Vector3 displacementVector = new Vector3(xDisplacement, yDisplacement, 0);
        
        transform.Translate(displacementVector * actualSpeed * Time.deltaTime);
        if (Input.GetKey("a")){
            
            sprite.flipX = false;
} 
        if (Input.GetKey("d")) {
            sprite.flipX = true;
        }

        if (isGrounded && xDisplacement ==0)
        {
            anim.Play("idle");
        }

        if (rb.velocity.y < -0.1)
        {
            anim.Play("Falling");
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        anim.Play("die");
        isRunning = false;
        if (!isRestarting)
        {
            isRestarting = true;
            StartCoroutine(RestartGame());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        anim.Play("jump");
        rb.AddForce(new Vector2(0, jumpForce*1.5f), ForceMode2D.Impulse);
    }
   private void Run()
   {
       anim.Play("run");
    if (isGrounded) State = States.run;
   }

   private IEnumerator RestartGame()
   {
       yield return new WaitForSeconds(1.5f);
       SceneManager.LoadScene("SampleScene");
   }
   private IEnumerator Attack()
   {
       yield return new WaitForSeconds(0.8f);
       isAttacking = false;
   }
}