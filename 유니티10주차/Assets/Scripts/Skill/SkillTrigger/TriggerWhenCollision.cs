using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhenCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ProjectileBase myBase = GetComponent<ProjectileBase>();

        //�� ������Ʈ�� ����ü������ �ߵ��� �ű���, �� ����� �ƴϾ�� �ߵ��� �ſ���!
        if(myBase != null && other.gameObject != myBase.from)
        {
            List<CharacterBase> targetList = new List<CharacterBase>();

            //���� ������� ĳ���ͺ��̽��� �ִٸ�!
            CharacterBase target = other.gameObject.GetComponent<CharacterBase>();
            if (target != null)
            {
                //���� �༮ ��Ͽ� ���� �ָ� �־��� ���̱���!
                targetList.Add(target);

                //�� �ְ� �� ������� ��ų�� �����մϴ�!
                myBase.ActivateSkill(targetList);
            };
        };
    }
}
