using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAction_Damage : SkillAction
{
    public int amount;

    public override void Activate(List<CharacterBase> targets)
    {
        foreach(CharacterBase current in targets)
        {
            current.GetDamage(amount);
        };
    }
}
