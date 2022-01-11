using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // 1. �ʱ�ȭ

    // 1-1. ���� ������Ʈ ������ ��, ���� ����
    void Awake()
    {
        Debug.Log("�÷��̾� �����Ͱ� �غ�Ǿ����ϴ�.");
    }

    // 1-2. ���� ������Ʈ�� Ȱ��ȭ �Ǿ��� ��
    void OnEnable()
    {
        Debug.Log("�÷��̾ �α��� �߽��ϴ�.");
    }

    // 1-3. ������Ʈ �������� ������ ���ʷ� ����
    void Start()
    {
        Debug.Log("��� ��� ì����ϴ�.");
    }

    // 2. ��������
    // 2-1. ���� ���� ������Ʈ
    void FixedUpdate()
    {
        Debug.Log("�̵�~");
    }

    //3. ���ӷ��� (�ֱ������� ����)
    //3-1. ���ӷ��� ������Ʈ
    void Update()
    {
        Debug.Log("���� ���!!");
    }

    //3-2. ��� ������Ʈ ������ ����
    void LateUpdate()
    {
        Debug.Log("����ġ");
    }

    //3-3. ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��� ��
    void OnDisable()
    {
        Debug.Log("�÷��̾ �α׾ƿ��Ͽ����ϴ�.");
    }

    //4. ��ü
    //4-1. ���� ������Ʈ�� ������ ��
    void OnDestory()
    {
        Debug.Log("�÷��̾� �����͸� ��ü�߽��ϴ�.");
    }
}
