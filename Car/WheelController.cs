using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 300f; // Ускорение
    public float breakingForce = 300f; // Сила торможения
    public float maxTurnAngle = 10f; // Поворот

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public Joystick joystick;

    private void FixedUpdate() {

        currentAcceleration = acceleration * joystick.Vertical;

        if (Input.GetKey(KeyCode.Space)) // торможение при пробеле
            currentBreakForce = breakingForce;
        else currentBreakForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * joystick.Horizontal;
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform wheel) {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        wheel.position = position;
        wheel.rotation = rotation;
    }

}
