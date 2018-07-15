using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    static Animator anim;
    public int speedWalking = 10;
    public int speedRunning = 50;
    public int jumpForce = 6;
    private Rigidbody2D rb;
    private bool isGrounded;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {

        //Walk and Run
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            float translationRunning = Input.GetAxisRaw("Horizontal") * speedRunning * Time.deltaTime;
            transform.Translate(translationRunning, 0, 0);
        }
        else {
            float translationWalking = Input.GetAxisRaw("Horizontal") * speedWalking * Time.deltaTime;
            transform.Translate(translationWalking, 0, 0);
            if (translationWalking == 0)
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", false);

            }
            else {
                print("Here");
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
            }
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0.0F, 2.0F) * jumpForce, ForceMode2D.Impulse);
        }
        

        
	}

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }
}
