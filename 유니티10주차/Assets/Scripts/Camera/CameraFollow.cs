using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 boom;

    void Update()
    {
        transform.position = target.position + boom;
        transform.position = new Vector3(transform.position.x, transform.position.y,  Mathf.Max(transform.position.z, -0.6f)  );
    }
}
