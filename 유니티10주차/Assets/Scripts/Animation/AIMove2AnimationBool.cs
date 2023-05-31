using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove2AnimationBool : MonoBehaviour
{
    [SerializeField]
    private AIMoveTo from;

    [SerializeField]
    private Animator to;

    [SerializeField]
    private string name;

    void Update()
    {
        to.SetBool(name, from.IsWalking);
    }
}
