using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    BoxCollider2D monsterBoxCollider;
    public int nextMove;
    public float nextMoveTime = 1f;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        monsterBoxCollider = GetComponent<BoxCollider2D>();
        Invoke("Move", nextMoveTime);
    }

    public void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        Vector2 frontCheck = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        // block check
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(frontCheck, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontCheck, Vector3.down, 2f, LayerMask.GetMask("Block"));

            if (rayHit.collider == null)
            {
                Turn();
            }
        }
    }

    void Move()
    {
        // set next move
        nextMove = Random.Range(-1, 2);
        nextMoveTime = Random.Range(0f, 5f);

        // set direction
        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == -1 ? true : false;
            //spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // set animation parmeter
        animator.SetInteger("walkSpeed", nextMove);
        Invoke("Move", nextMoveTime);
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        CancelInvoke();
        Invoke("Move", nextMoveTime);
    }

    public void OnDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        monsterBoxCollider.enabled = false;
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        Invoke("DeActive", 5);

    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
