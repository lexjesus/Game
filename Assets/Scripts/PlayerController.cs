using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private Animator anim;
    public float health;
    


    public Text healthDisplay;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
}

    private void FixedUpdate()
    {
	if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight && moveInput < 0)
        {
            Flip();
        }
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        healthDisplay.text = System.Convert.ToInt32(health).ToString();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGrounded);
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);

        }

        
    }


    public void Flip()
    {
        Transform armGun = GameObject.FindGameObjectWithTag("GunArm").GetComponent<Transform>();
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Vector3 ScalerG = armGun.localScale;
        ScalerG.x *= -1;
        ScalerG.y *= -1;
        Scaler.x *= -1;
        armGun.localScale = ScalerG;
        transform.localScale = Scaler;
    }

    
}
