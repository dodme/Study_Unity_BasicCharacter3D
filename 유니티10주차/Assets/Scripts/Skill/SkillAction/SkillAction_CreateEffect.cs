using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAction_CreateEffect : SkillAction
{
    public GameObject targetEffect;

    public override void Activate(List<CharacterBase> targets)
    {
        //�������� ����� �� �־, �³׵����� ���� ����Ʈ ���!
        foreach(CharacterBase current in targets)
        {
            GameObject effect = Instantiate(targetEffect);

            effect.transform.position = current.transform.position;
        };
    }

    public override void Activate(Vector3 wantLocation)
    {
        GameObject effect = Instantiate(targetEffect);
        effect.transform.position = transform.position;
    }
}
