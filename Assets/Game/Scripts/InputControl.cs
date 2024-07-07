using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public event Action<float> inputControl;
    void Start()
    {
        
    }

    
    void Update()
    {
        float hSpeed = Input.GetAxis("Horizontal");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                hSpeed = 1f;
            }
            else if (touch.position.x < Screen.width / 2)
            {
                hSpeed = -1f;
            }
        }
        inputControl?.Invoke(hSpeed);
    }
}
