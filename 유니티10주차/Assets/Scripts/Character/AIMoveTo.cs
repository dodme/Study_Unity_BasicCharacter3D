using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMoveTo : VectorInput
{
    NavMeshAgent agent;

    //밖에서 제 에이전트를 바꿀 수 없게! 가져가게만 할 거에요!
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
        //원래 하던 기능 그대로 수행~!
        base.ValueIn(wantValue);
        
        agent.SetDestination(value);
    }
}
