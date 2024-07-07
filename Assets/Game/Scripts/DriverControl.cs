using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverControl : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float speedZoom = 1;
    private float _zoom = 45f;
    private InterfaceControl _interfaceControl;


    private void Start()
    {
        _interfaceControl = FindObjectOfType<InterfaceControl>();
        camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(InterfaceReaction());
        Invoke(nameof(ReactionDeath), 2.5f);
    }

    private void ReactionDeath()
    {
        _interfaceControl.OnPanelGameOver();
    }

    private IEnumerator InterfaceReaction()
    {
        float prevZoom = camera.fieldOfView;
        float elapsedTime = 0f;

        while (elapsedTime < 1f) 
        {
            camera.fieldOfView = Mathf.Lerp(prevZoom, _zoom, elapsedTime);
            elapsedTime += Time.deltaTime * speedZoom;
            yield return null;
        }

        camera.fieldOfView = _zoom;
    }

}
