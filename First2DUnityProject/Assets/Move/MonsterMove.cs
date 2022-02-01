using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public int nextMove;
    public float nextThinkTime;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", nextThinkTime);
    }

    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        Vector2 frontVector = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        // block check
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(frontVector, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("Block"));

            if (rayHit.collider == null)
            {
                Turn();
            }
        }
    }

    void Think()
    {
        // set next move
        nextMove = Random.Range(-1, 2);
        nextThinkTime = Random.Range(0f, 5f);
        Invoke("Think", nextThinkTime);

        // set direction
        if(nextMove != 0)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // set animation parmeter
        animator.SetInteger("walkSpeed", nextMove);
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        CancelInvoke();
        Invoke("Think", nextThinkTime);
    }
}
