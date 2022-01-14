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

    //RigidBody ���� �ڵ�� FixedUpdate �޼��� ���� �ۼ��ϴ� �� ����
    private void FixedUpdate()
    {
        ChangeVelocity();
        AddForce();
        AddTorque();
    }

    public void ChangeVelocity()
    {
        //�ӷ� �ٲٱ�
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
        //�׼��� ������������ �ӵ� ����
        rigid.AddForce(vec * 1, ForceMode.Impulse);
    }

    public void AddTorque()
    {
        //ȸ���� �ֱ�
        if (Input.GetKeyDown(KeyCode.R)){

            rigid.AddTorque(new Vector3(3, 0, 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�浹�� �Ͼ�� �ִ� ��
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 3, ForceMode.Impulse);
        }
    }
}
