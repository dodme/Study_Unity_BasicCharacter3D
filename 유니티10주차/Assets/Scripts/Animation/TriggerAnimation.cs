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
            //본인의 위치에서, 해당하는 방향을 바라보게!
            character.transform.LookAt(character.transform.position + value);

            character.anim.SetTrigger(triggerName);
        };
    }
}
