using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float itemNextMove;
    public float nextMoveTime;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        itemNextMove = 0.5f;
        Move();
    }

    void FixedUpdate()
    {
    }
    
    public void Move()
    {
        Debug.Log(itemNextMove);
        itemNextMove *= -1f;
        rigid.velocity = new Vector2(0, itemNextMove);
        Invoke("Move", 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

        }
    }
}
