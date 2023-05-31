using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : VectorInput
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float speed;

    void Create()
    {
        GameObject current = Instantiate(projectile);
        ProjectileVelocity proj = current.GetComponent<ProjectileVelocity>();

        current.transform.position = transform.position;

        proj.direction = direction;
        proj.speed = speed;
    }

    public override void ValueIn(Vector3 wantValue)
    {
        base.ValueIn(wantValue);

        direction = (wantValue - transform.position).normalized;
        direction.y = 0;
        Create();
    }
}
