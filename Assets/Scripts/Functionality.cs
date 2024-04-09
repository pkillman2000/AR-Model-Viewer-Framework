using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functionality : MonoBehaviour
{
    [SerializeField]
    private GameObject _lightsObject;
    private bool _lightsActive = false;

    public void ToggleLights()
    {
        _lightsActive = !_lightsActive;
        _lightsObject.SetActive(_lightsActive);
    }
}
