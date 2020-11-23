using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RandomScale : MonoBehaviour
{
    public float minScale = 1f, maxScale = 2f;

    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(random, random, random);
    }

    
}
