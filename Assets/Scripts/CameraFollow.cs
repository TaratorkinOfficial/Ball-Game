using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = FindObjectOfType<PhysicBall>().transform;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y + 60, target.position.z - 26), .6f);
    }
}
