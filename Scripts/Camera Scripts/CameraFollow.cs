using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform myTransform;
    private Transform target;
    public Vector3 offset = new Vector3(3f, -7.5f, -3f);

    void Awake()
    {
        target = GameObject.Find("Ninja").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            myTransform.position = target.position + offset;
            myTransform.LookAt(target.position, Vector3.up);
        }
    }
}
