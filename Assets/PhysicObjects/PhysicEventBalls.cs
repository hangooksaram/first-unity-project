using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicEventBalls : MonoBehaviour
{
    MeshRenderer mesh;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    //물리적 충돌 시작 될 때
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PhysicBall")
        {
            material.color = new Color(Random.Range(0f, 255f), Random.Range(0f, 255f), Random.Range(0f, 255f));
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{

    //}
}
