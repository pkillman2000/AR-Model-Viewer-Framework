using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLights : MonoBehaviour
{
    [SerializeField]
    private GameObject _blinkingLights;
    [SerializeField]
    private float _blinkRate;

    private float _timer;
    private bool _isActive = true;

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _blinkRate)
        {
            _isActive = !_isActive; 
            _blinkingLights.SetActive(_isActive);
            _timer -= _blinkRate;
        }
    }
}
