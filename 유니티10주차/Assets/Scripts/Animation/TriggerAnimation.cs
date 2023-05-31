using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : VectorInput
{
    [SerializeField]
    public CharacterBase character;

    [SerializeField]
    public string triggerName;

    public override void ValueIn(Vector3 wantValue)
    {
        base.ValueIn(wantValue);

        if(character != null && character.anim != null)
        {
            //������ ��ġ����, �ش��ϴ� ������ �ٶ󺸰�!
            character.transform.LookAt(character.transform.position + value);

            character.anim.SetTrigger(triggerName);
        };
    }
}
