using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResourceContainer : MonoBehaviour
{
    public int currentValue;
    public int maxValue;
    public int minValue;

    void Update()
    {
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        /*
        if(maxValue < currentValue)
        {
            currentValue = maxValue;
        }
        if(minValue > currentValue)
        {
            currentValue = minValue;
        };
        */
    }
}
