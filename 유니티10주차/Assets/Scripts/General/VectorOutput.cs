using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorOutput : MonoBehaviour
{
    //계산을 했을 때, 나눠줄 애들!
    public List<VectorInput> targets;

    protected virtual void Distribute(Vector3 result)
    {
        //foreach : 리스트나 배열처럼 여러개가 들어있는 곳에서
        //          하나하나 돌아다니면서 원하는 내용을 실행시킵니다!
        //       (자료형)  (부를 별명) in (리스트)
        foreach(VectorInput current in targets)
        {
            current.ValueIn(result);
        };
    }
}
