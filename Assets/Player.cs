using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Start()
    {
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        Debug.Log("�÷��̾�� �����Դϴ�.");
    }
}
