using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMoveTo : VectorInput
{
    NavMeshAgent agent;

    //�ۿ��� �� ������Ʈ�� �ٲ� �� ����! �������Ը� �� �ſ���!
    public NavMeshAgent GetAgent { get { return agent; } }

    Rigidbody rigid;

    public bool IsWalking 
    { 
        get 
        {
            return (agent.destination - transform.position).magnitude > 1.0f;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        value = transform.position;

        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsWalking);
        if (rigid != null)
        {
            rigid.velocity = Vector3.zero;
        };
    }

    public override void ValueIn(Vector3 wantValue)
    {
        //���� �ϴ� ��� �״�� ����~!
        base.ValueIn(wantValue);
        
        agent.SetDestination(value);
    }
}
