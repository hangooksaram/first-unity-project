using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;


    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 5);
    }

    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
    }
}
