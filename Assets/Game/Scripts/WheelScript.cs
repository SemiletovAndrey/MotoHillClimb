using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationForward;
    [SerializeField] private float accelerationBackward;
    [SerializeField] private float speed;

    private InputControl _control;
    private WheelJoint2D _wheel;
    private JointMotor2D _motor;

    void Start()
    {
        _wheel = GetComponent<WheelJoint2D>();
        _motor = _wheel.motor;
        _control = FindObjectOfType<InputControl>();
        _control.inputControl += MotorControl;
    }


    private void MotorControl(float hSpeed)
    {
        if (hSpeed > 0 || hSpeed < 0)
        {
            speed = Mathf.Clamp(speed + Time.deltaTime * accelerationForward, 0f, maxSpeed);
            _motor.motorSpeed = hSpeed * -speed;
            _wheel.motor = _motor;
        }
        else if (hSpeed == 0)
        {
            speed = 0;
            _wheel.useMotor = false;
        }
        
    }
}

