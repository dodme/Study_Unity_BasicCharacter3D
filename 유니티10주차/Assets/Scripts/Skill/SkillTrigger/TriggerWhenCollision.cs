using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhenCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ProjectileBase myBase = GetComponent<ProjectileBase>();

        //이 오브젝트가 투사체여야지 발동할 거구요, 쏜 사람은 아니어야 발동할 거에요!
        if(myBase != null && other.gameObject != myBase.from)
        {
            List<CharacterBase> targetList = new List<CharacterBase>();

            //맞은 대상한테 캐릭터베이스가 있다면!
            CharacterBase target = other.gameObject.GetComponent<CharacterBase>();
            if (target != null)
            {
                //맞을 녀석 목록에 닿은 애를 넣어줄 것이구요!
                targetList.Add(target);

                //그 애가 들어간 목록으로 스킬을 시전합니다!
                myBase.ActivateSkill(targetList);
            };
        };
    }
}
