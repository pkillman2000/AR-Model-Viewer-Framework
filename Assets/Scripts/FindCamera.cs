using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCamera : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    private Camera _camera;
    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        if(_camera == null)
        {
            Debug.LogError("Camera not found!");
        }
        else
        {
            _canvas.worldCamera = _camera;
        }
    }
}
