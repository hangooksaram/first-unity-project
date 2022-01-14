using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBall : MonoBehaviour
{

    Rigidbody rigid;
    // Start is called before the first frame update
    void Start() {
        rigid = GetComponent<Rigidbody>();
        //rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
        
    }

    //RigidBody 관련 코드는 FixedUpdate 메서드 내에 작성하는 것 권장
    private void FixedUpdate()
    {
        ChangeVelocity();
        AddForce();
        AddTorque();
    }

    public void ChangeVelocity()
    {
        //속력 바꾸기
        if (Input.GetButtonDown("Jump"))
        {
            rigid.velocity = new Vector3(0, 3, 0);
        }
    }

    public void AddForce()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);
        //액션이 가해질때마다 속도 증가
        rigid.AddForce(vec * 1, ForceMode.Impulse);
    }

    public void AddTorque()
    {
        //회전력 주기
        if (Input.GetKeyDown(KeyCode.R)){

            rigid.AddTorque(new Vector3(3, 0, 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //충돌이 일어나고 있는 중
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 3, ForceMode.Impulse);
        }
    }
}
