
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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (isGrounded) State = States.idle;

        if(Input.GetButton("Horizontal"))
        Run();
       // if (isGrounded && Input.GetButtonDown("jump"))
       // Jump();
    

        float xDisplacement = Input.GetAxis("Horizontal");
        float yDisplacement = 0;
        float actualSpeed = 0;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("SampleScene");
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

        rb.AddForce(new Vector2(0, jumpForce*1.5f), ForceMode2D.Impulse);
    }
   private void Run()
   {
       
    if (isGrounded) State = States.run;
   }

}