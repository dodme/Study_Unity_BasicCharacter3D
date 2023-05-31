using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClickType
{
    LeftClick = 0,
    RightClick = 1
}

public class Mouse2Location : VectorOutput
{
    [SerializeField]
    private ClickType wantClickType;

    [SerializeField]
    private ActionType wantAction;

    void Update()
    {
        //0���� ����, 1���� ������ Ŭ��!
        if (Input.GetMouseButtonDown((int)wantClickType))
        {
            //ray�� ��Ƽ�, ���� ������Ʈ�� �����մϴ�!
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
            
            //Ŭ���� ��ġ�� ��� VectorInput���� �����ٰԿ�!
            Distribute(hit.point);
        };
    }

    override protected void Distribute(Vector3 result)
    {
        //foreach : ����Ʈ�� �迭ó�� �������� ����ִ� ������
        //          �ϳ��ϳ� ���ƴٴϸ鼭 ���ϴ� ������ �����ŵ�ϴ�!
        //       (�ڷ���)  (�θ� ����) in (����Ʈ)
        foreach (VectorInput current in targets)
        {
            //���ó�� �ڷḦ �ַ��� �߽��ϴ�! �ٵ� �갡? ĳ���ͳ׿�?
            if(current.GetType() == typeof(CharacterBase))
            {
                //�׷��� �׳� ��ġ�� �ִ� ���� �ƴϰ�, �� �ϰ� ���� ������ �����ٰԿ�!
                ((CharacterBase)current).ValueIn(result, wantAction);
            }
            else
            {
                current.ValueIn(result);
            };
        };
    }
}
