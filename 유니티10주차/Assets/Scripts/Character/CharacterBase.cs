using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    Move,
    BasicAttack
}

public class CharacterBase : VectorInput
{
    [SerializeField]
    private GameObject basicAttack;

    //남은 평타 쿨타임!
    [SerializeField]
    private float BasicAttackCooldownCurrent;

    //평타 쿨타임이 얼마나 오래 돌 것인지 결정!
    [SerializeField]
    private float BasicAttackCooldownMax;

    //걷고 싶은데 걸을 수가 없어요..
    [SerializeField]
    private float walkDisableTime;

    [SerializeField]
    private AIMoveTo movement;

    [SerializeField]
    public Animator anim;

    [SerializeField]
    private ResourceContainer health;

    private void Update()
    {
        if (walkDisableTime > 0.0f)
        {
            //못 움직이니까 그냥 목적지가 제 위치 그대로!
            movement.GetAgent.SetDestination(transform.position);

            walkDisableTime -= Time.deltaTime;
        };
    }

    /// <summary> 스킬 시전! </summary>
    public void SkillCast(GameObject targetSkill)
    {
        //일단 만들으라고 하니까 만듭니다!
        GameObject currentSkill = Instantiate(targetSkill);

        //만들었는데 스킬인지 확인!
        SkillBase currentBase = currentSkill.GetComponent<SkillBase>();

        //스킬이 아니었으면 파괴하고 끝내기!
        if(currentBase == null) { Destroy(currentSkill); return; };

        //시전 시간만큼 걷기 불가능하다고 알리기!
        //원래 이동 불가능한 시간과, 이 기술때문에 이동 불가능한 시간을 확인을 해서!
        //더 큰 쪽으로 적용할게요!
        walkDisableTime = Mathf.Max(currentBase.StartDelay, walkDisableTime);

        //제가 시전했다고 알립니다.
        currentBase.From = gameObject;

        //제 애니메이션에서 스킬 모션을 실행한다고 하면 됩니다!
        currentBase.SkillAnimation.character = this;

        //제 위치에서 시작!
        currentSkill.transform.position = transform.position;

        //타겟 위치를 지정해줍니다!
        currentBase.targetLocation = value;

        //높낮이는 무시하기 위해서 y축을 맞춰줍니다!
        currentBase.targetLocation.y = transform.position.y;
    }

    public void ValueIn(Vector3 wantValue, ActionType type)
    {
        value = wantValue;

        switch(type)
        {
            //공격 명령이 들어오면, 평타를 시전합니다!
            case ActionType.BasicAttack:
                //다음 공격 가능한 시간에 도달했는지!
                if(BasicAttackCooldownCurrent <= Time.realtimeSinceStartup)
                {
                    SkillCast(basicAttack);
                    //시전했으니, 쿨타임을 현재 시간에서 + 몇 초로!
                    BasicAttackCooldownCurrent = 
                        Time.realtimeSinceStartup + BasicAttackCooldownMax 
                        + basicAttack.GetComponent<SkillBase>().StartDelay;
                };
                break;
            //이동 명령이 들어오면, 이동 기능에 넣어줍니다!
            case ActionType.Move:
                //이동불가가 풀려야 이동 명령 가능!
                if(walkDisableTime <= 0.0f)
                {
                    movement.ValueIn(wantValue);
                };
                break;
        };
    }

    public void GetDamage(int amount)
    {
        health.currentValue -= amount;
    }
}
