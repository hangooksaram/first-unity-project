using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    public void Start()
    {
    }
    public void Update()
    {
        MoveActions();
    }

    public void MoveActions()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal") *Time.deltaTime,  Input.GetAxis("Vertical")*Time.deltaTime, 0);
        transform.Translate(vec);


        Vector3 target = new Vector3(4, 0, 0);
        // �ʱ�ȭ
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 initiallPosition = new Vector3(-4, 1.5f, 0);
            transform.position = Vector3.MoveTowards(transform.position, initiallPosition, 1f);
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            // 1. MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, target, 1f);
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            // 2. SmoothDamp
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.1f);
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            // 3. Lerp (���� ����)
            transform.position = Vector3.Lerp(transform.position, target, 1f);
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {

            // 4. SLerp (���� ���� ����)
            transform.position = Vector3.Slerp(transform.position, target, 0.05f);
        }
    }
}
