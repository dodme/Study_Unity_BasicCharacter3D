using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorInput : MonoBehaviour
{
    [SerializeField]
    protected Vector3 value;

    public virtual void ValueIn(Vector3 wantValue)
    {
        value = wantValue;
    }
}
