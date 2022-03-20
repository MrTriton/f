using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public bool isJumping = false;
    public bool isGrounded = true;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //GetKey - Przyciśnięty przycisk
        //GetKeyDown - Przycisk AKTUALNIE wciskany 
        //GetKeyUp - Przycisk został zwolniony/puszczony
        // Rigidbody 2D, Box Collider 2D

        float xDisplacement = Input.GetAxis("Horizontal");
        float yDisplacement = 0;
        //Debug.Log("wartość przesunięcia po osi X: " + xDisplacement);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        Vector3 displacementVector = new Vector3(xDisplacement, yDisplacement, 0);
        transform.Translate(displacementVector*Time.deltaTime*speed);

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
}
