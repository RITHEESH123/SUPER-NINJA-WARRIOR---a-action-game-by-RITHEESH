using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RotateObject : MonoBehaviour
{
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
