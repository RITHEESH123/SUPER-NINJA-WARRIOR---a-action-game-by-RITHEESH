using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DestroyOverTime : MonoBehaviour
{
    public float timer = 3f;
    void Start()
    {
        Destroy(gameObject, timer);
    }

    
}
