using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movementDirection;

    private Rigidbody myBody;

    public float walkingSpeed = 5f;
    public float walkingSnapyness = 50f;
    public float turningSmoothing = 0.3f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetVelocity = movementDirection * walkingSpeed;
        Vector3 deltaVelocity = targetVelocity - myBody.velocity;

        if (myBody.useGravity)
        {
            deltaVelocity.y = 0f;
        }

        myBody.AddForce(deltaVelocity * walkingSnapyness, ForceMode.Acceleration);

        Vector3 faceDir = movementDirection;

        if (faceDir == Vector3.zero)
        {
            myBody.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, faceDir, Vector3.up);
            myBody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
        }
    }

    float AngleAroundAxis(Vector3 dirA,Vector3 dirB,Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);

        float angle = Vector3.Angle(dirA, dirB);

        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
    }





}
