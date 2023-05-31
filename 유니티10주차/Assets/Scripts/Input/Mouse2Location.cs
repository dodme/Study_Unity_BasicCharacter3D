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
        //0번은 왼쪽, 1번은 오른쪽 클릭!
        if (Input.GetMouseButtonDown((int)wantClickType))
        {
            //ray를 쏘아서, 맞은 오브젝트를 저장합니다!
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
            
            //클릭한 위치를 모든 VectorInput한테 나눠줄게요!
            Distribute(hit.point);
        };
    }

    override protected void Distribute(Vector3 result)
    {
        //foreach : 리스트나 배열처럼 여러개가 들어있는 곳에서
        //          하나하나 돌아다니면서 원하는 내용을 실행시킵니다!
        //       (자료형)  (부를 별명) in (리스트)
        foreach (VectorInput current in targets)
        {
            //평소처럼 자료를 주려고 했습니다! 근데 얘가? 캐릭터네요?
            if(current.GetType() == typeof(CharacterBase))
            {
                //그러면 그냥 위치만 주는 것이 아니고, 뭘 하고 싶은 건지도 전해줄게요!
                ((CharacterBase)current).ValueIn(result, wantAction);
            }
            else
            {
                current.ValueIn(result);
            };
        };
    }
}
