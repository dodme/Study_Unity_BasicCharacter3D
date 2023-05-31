using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorOutput : MonoBehaviour
{
    //����� ���� ��, ������ �ֵ�!
    public List<VectorInput> targets;

    protected virtual void Distribute(Vector3 result)
    {
        //foreach : ����Ʈ�� �迭ó�� �������� ����ִ� ������
        //          �ϳ��ϳ� ���ƴٴϸ鼭 ���ϴ� ������ �����ŵ�ϴ�!
        //       (�ڷ���)  (�θ� ����) in (����Ʈ)
        foreach(VectorInput current in targets)
        {
            current.ValueIn(result);
        };
    }
}
