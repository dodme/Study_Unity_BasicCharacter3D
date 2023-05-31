using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    /// <summary> �� ��� �����س����Կ�! </summary>
    public GameObject from;

    /// <summary> Ÿ�� ������Ʈ�� �ִٸ�, ���� �̻���ó�� ���ư� �ſ���! </summary>
    public GameObject targetObject;

    /// <summary> Ÿ���� ���ٸ�, �׳� ���� �������� ���ư��� ����?</summary>
    public Vector3 direction;

    /// <summary> �̻����� �������� �ʽ��ϴ�. �̻����� ���� �� �ִ� �ִ� �ð��� �����ٰԿ�! </summary>
    public float leftTime;

    /// <summary> �̻����� ���ư��� �ӵ�����! </summary>
    public float speed;

    void Update()
    {
        //���� �ð��� ������ ��� ������!
        if(leftTime > 0.0f)
        {
            leftTime -= Time.deltaTime;
        }
        else
        {
            //���� �ð��� ������.. ���⼭ ��ų�� �����Ű�� �����ϴ�!
            ActivateSkill(transform.position);
        };

        //���� �Ѿƾ��ϴ� ����� �ֽ��ϴ�!
        if(targetObject != null)
        {
            //������� ���� ������ ����غ��Կ�!
            //���� ����� ���̸� ���ؼ�, ���� �����ϴ��� ���� �� �ſ���!
            direction = targetObject.transform.position - transform.position;
            //Normalize��� �ϸ�, ���ⰰ�� �������� ���� �� �־��!
            direction.Normalize();
        };

        //����� ������ �̵��ҰԿ�! (�ð��� ���缭!)
        transform.position += direction * Time.deltaTime * speed;
    }

    public void ActivateSkill(Vector3 wantLocation)
    {
        //�� �߻�ü�� ����ִ� ��� ��ų �׼��� �� �ܾ�ͼ�
        var skillActions = GetComponents<SkillAction>();

        //���� �����Ű��!
        foreach(SkillAction current in skillActions)
        {
            current.Activate(wantLocation);
        };


        Destroy(gameObject);
    }

    public void ActivateSkill(List<CharacterBase> targets)
    {
        Destroy(gameObject);
    }
}
