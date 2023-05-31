using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    /// <summary> 스킬의 대상이 되는 애들! </summary>
    public List<GameObject> targetObjectList;

    /// <summary> 스킬의 목표 위치! 어디로 쏠까요! </summary>
    public Vector3 targetLocation;

    /// <summary> 무엇을 쏠 것인지! </summary>
    public GameObject SkillPrefab;

    /// <summary> 누가 쐈나? </summary>
    public GameObject From;

    /// <summary> 이 스킬을 쓸 때에, 어떤 이름의 모션을 쓰면 되나요? </summary>
    public TriggerAnimation SkillAnimation;

    /// <summary> 만들어지고 몇 초 뒤에 시작할 것인지! </summary>
    public float StartDelay = 0.0f;

    /// <summary> 시전자한테 계속 붙어있어야 하는지? </summary>
    public bool FixToFromObject = false;

    private void Start()
    {
        //                      (목표지점 - 원래지점).normalized = 목표로 가는 방향 벡터!
        SkillAnimation.ValueIn((targetLocation - From.transform.position).normalized);
    }

    private void Update()
    {
        //아직 시작할 때가 되지 않았어요!
        if (StartDelay > 0.0f)
        {
            //카운트 다운 해줍니다!
            StartDelay -= Time.deltaTime;
        }
        //카운트 다운이 끝나서, 이제 만들 땝니다!
        else
        {
            //일단 스킬 만드는데, 제 위치에서 노회전으로 만들게요!
            ProjectileBase proj = Instantiate(SkillPrefab, transform.position, Quaternion.identity).GetComponent<ProjectileBase>();

            //쏜 사람을 전달해줍니다!
            proj.from = From;

            //제 위치에서, 원하는 위치로 가는 방향을 넣어줄 거구요!
            proj.direction = (targetLocation - transform.position).normalized;

            //일단 첫 번째 타겟을 대상으로 쏘도록 할게요!
            if(targetObjectList.Count > 0)
            {
                proj.targetObject = targetObjectList[0];
            };

            //발사한 후에는, 스킬 자체를 일단 지워줄게요!
            Destroy(gameObject);
        };
    }
}
