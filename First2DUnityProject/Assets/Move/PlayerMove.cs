using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        // Set Speed When Stop
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // Direction Transition
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        // Animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            animator.SetBool("isWalking", false); 
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    public void FixedUpdate()
    {
        // Move ( Left Arrow & Right Arrow )
        float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        rigid.AddForce(Vector2.right * horizontal, ForceMode2D.Impulse);
        //rigid.AddForce(Vector2.up * vertical, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed) // Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // Landing Platform
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Block"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Trap")
        {
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPosition)
    {
        // change layer (immortal active)
        gameObject.layer = 10;

        // change color
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);

        // reaction
        int reactDirection = transform.position.x - targetPosition.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(reactDirection, 1) * 7, ForceMode2D.Impulse);

        // animation
        animator.SetTrigger("doDamaged");

        Invoke("OffDamaged", 1);
    }

    void OffDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        gameObject.layer = 9;
    }

}
