using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Move : MonoBehaviour
{
    public float X = 0f;
    public float Y = 0f;
    public float Z = 0f;

    public bool local = false;

    // Update is called once per frame
    void Update()
    {
        if (local)
        {
            transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime);
        }
        if (!local)
        {
            transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime, Space.World);
        }
    }
}
