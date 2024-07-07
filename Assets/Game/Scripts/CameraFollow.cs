using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float Speed = 0.01f;
    [SerializeField] private Transform PlayerObject;

    void Update()
    {
        var cameraPosition = transform.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, PlayerObject.position.x, Speed);
        cameraPosition.y = Mathf.Lerp(cameraPosition.y, PlayerObject.position.y, Speed);
        transform.position = cameraPosition;
    }
}
