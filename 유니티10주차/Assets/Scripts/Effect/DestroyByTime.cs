using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float timeLeft;

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        };
    }
}
