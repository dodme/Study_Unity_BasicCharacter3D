using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    /// <summary> ��ų�� ����� �Ǵ� �ֵ�! </summary>
    public List<GameObject> targetObjectList;

    /// <summary> ��ų�� ��ǥ ��ġ! ���� ����! </summary>
    public Vector3 targetLocation;

    /// <summary> ������ �� ������! </summary>
    public GameObject SkillPrefab;

    /// <summary> ���� ����? </summary>
    public GameObject From;

    /// <summary> �� ��ų�� �� ����, � �̸��� ����� ���� �ǳ���? </summary>
    public TriggerAnimation SkillAnimation;

    /// <summary> ��������� �� �� �ڿ� ������ ������! </summary>
    public float StartDelay = 0.0f;

    /// <summary> ���������� ��� �پ��־�� �ϴ���? </summary>
    public bool FixToFromObject = false;

    private void Start()
    {
        //                      (��ǥ���� - ��������).normalized = ��ǥ�� ���� ���� ����!
        SkillAnimation.ValueIn((targetLocation - From.transform.position).normalized);
    }

    private void Update()
    {
        //���� ������ ���� ���� �ʾҾ��!
        if (StartDelay > 0.0f)
        {
            //ī��Ʈ �ٿ� ���ݴϴ�!
            StartDelay -= Time.deltaTime;
        }
        //ī��Ʈ �ٿ��� ������, ���� ���� ���ϴ�!
        else
        {
            //�ϴ� ��ų ����µ�, �� ��ġ���� ��ȸ������ ����Կ�!
            ProjectileBase proj = Instantiate(SkillPrefab, transform.position, Quaternion.identity).GetComponent<ProjectileBase>();

            //�� ����� �������ݴϴ�!
            proj.from = From;

            //�� ��ġ����, ���ϴ� ��ġ�� ���� ������ �־��� �ű���!
            proj.direction = (targetLocation - transform.position).normalized;

            //�ϴ� ù ��° Ÿ���� ������� ��� �ҰԿ�!
            if(targetObjectList.Count > 0)
            {
                proj.targetObject = targetObjectList[0];
            };

            //�߻��� �Ŀ���, ��ų ��ü�� �ϴ� �����ٰԿ�!
            Destroy(gameObject);
        };
    }
}
