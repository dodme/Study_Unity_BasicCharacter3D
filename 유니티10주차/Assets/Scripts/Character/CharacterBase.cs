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

    //���� ��Ÿ ��Ÿ��!
    [SerializeField]
    private float BasicAttackCooldownCurrent;

    //��Ÿ ��Ÿ���� �󸶳� ���� �� ������ ����!
    [SerializeField]
    private float BasicAttackCooldownMax;

    //�Ȱ� ������ ���� ���� �����..
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
            //�� �����̴ϱ� �׳� �������� �� ��ġ �״��!
            movement.GetAgent.SetDestination(transform.position);

            walkDisableTime -= Time.deltaTime;
        };
    }

    /// <summary> ��ų ����! </summary>
    public void SkillCast(GameObject targetSkill)
    {
        //�ϴ� ��������� �ϴϱ� ����ϴ�!
        GameObject currentSkill = Instantiate(targetSkill);

        //������µ� ��ų���� Ȯ��!
        SkillBase currentBase = currentSkill.GetComponent<SkillBase>();

        //��ų�� �ƴϾ����� �ı��ϰ� ������!
        if(currentBase == null) { Destroy(currentSkill); return; };

        //���� �ð���ŭ �ȱ� �Ұ����ϴٰ� �˸���!
        //���� �̵� �Ұ����� �ð���, �� ��������� �̵� �Ұ����� �ð��� Ȯ���� �ؼ�!
        //�� ū ������ �����ҰԿ�!
        walkDisableTime = Mathf.Max(currentBase.StartDelay, walkDisableTime);

        //���� �����ߴٰ� �˸��ϴ�.
        currentBase.From = gameObject;

        //�� �ִϸ��̼ǿ��� ��ų ����� �����Ѵٰ� �ϸ� �˴ϴ�!
        currentBase.SkillAnimation.character = this;

        //�� ��ġ���� ����!
        currentSkill.transform.position = transform.position;

        //Ÿ�� ��ġ�� �������ݴϴ�!
        currentBase.targetLocation = value;

        //�����̴� �����ϱ� ���ؼ� y���� �����ݴϴ�!
        currentBase.targetLocation.y = transform.position.y;
    }

    public void ValueIn(Vector3 wantValue, ActionType type)
    {
        value = wantValue;

        switch(type)
        {
            //���� ����� ������, ��Ÿ�� �����մϴ�!
            case ActionType.BasicAttack:
                //���� ���� ������ �ð��� �����ߴ���!
                if(BasicAttackCooldownCurrent <= Time.realtimeSinceStartup)
                {
                    SkillCast(basicAttack);
                    //����������, ��Ÿ���� ���� �ð����� + �� �ʷ�!
                    BasicAttackCooldownCurrent = 
                        Time.realtimeSinceStartup + BasicAttackCooldownMax 
                        + basicAttack.GetComponent<SkillBase>().StartDelay;
                };
                break;
            //�̵� ����� ������, �̵� ��ɿ� �־��ݴϴ�!
            case ActionType.Move:
                //�̵��Ұ��� Ǯ���� �̵� ��� ����!
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
