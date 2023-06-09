using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVelocity : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
