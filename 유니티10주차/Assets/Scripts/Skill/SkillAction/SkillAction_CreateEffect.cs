using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAction_CreateEffect : SkillAction
{
    public GameObject targetEffect;

    public override void Activate(List<CharacterBase> targets)
    {
        //여러명이 대상일 수 있어서, 걔네들한테 전부 이펙트 재생!
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
