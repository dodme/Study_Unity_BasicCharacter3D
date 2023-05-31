using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    /// <summary> 쏜 사람 저장해놓을게요! </summary>
    public GameObject from;

    /// <summary> 타겟 오브젝트가 있다면, 유도 미사일처럼 날아갈 거에요! </summary>
    public GameObject targetObject;

    /// <summary> 타겟이 없다면, 그냥 같은 방향으로 날아가면 어떨까요?</summary>
    public Vector3 direction;

    /// <summary> 미사일은 영원하지 않습니다. 미사일이 있을 수 있는 최대 시간을 적어줄게요! </summary>
    public float leftTime;

    /// <summary> 미사일이 날아가는 속도에요! </summary>
    public float speed;

    void Update()
    {
        //남은 시간이 있으면 계속 가세요!
        if(leftTime > 0.0f)
        {
            leftTime -= Time.deltaTime;
        }
        else
        {
            //남은 시간이 없으면.. 여기서 스킬을 실행시키고 끝냅니다!
            ActivateSkill(transform.position);
        };

        //저희가 쫓아야하는 대상이 있습니다!
        if(targetObject != null)
        {
            //대상으로 가는 방향을 계산해볼게요!
            //저와 대상의 차이를 비교해서, 어디로 가야하는지 먼저 볼 거에요!
            direction = targetObject.transform.position - transform.position;
            //Normalize라고 하면, 방향같은 느낌으로 만들 수 있어요!
            direction.Normalize();
        };

        //계산한 방향대로 이동할게요! (시간에 맞춰서!)
        transform.position += direction * Time.deltaTime * speed;
    }

    public void ActivateSkill(Vector3 wantLocation)
    {
        //이 발사체에 들어있는 모든 스킬 액션을 다 긁어와서
        var skillActions = GetComponents<SkillAction>();

        //전부 실행시키기!
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
