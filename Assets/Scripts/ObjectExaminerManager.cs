using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ObjectExaminerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _examineTarget;
    [SerializeField]
    private GameObject _examineButton;
    [SerializeField]
    private GameObject _functionalityButton;
    private Functionality _functionality;

    private Vector3 _cachedPosition;
    private Quaternion _cachedRotation;
    private Vector3 _cachedScale;
    private GameObject _currentExaminedObject;
    private bool _isExamining;
    
    [SerializeField]
    private ARPlacementInteractable _placementInteractable;

    private void Start()
    {
        _examineButton.SetActive(false);
        _functionalityButton.SetActive(false);
    }

    /*
     * This will limit the number of objects
     * that can be displayed to one.
     * It sets the Placement Interactable
     * to inactive.
    */
    public void ObjectPlaced(GameObject objectExaminer)
    {
        _placementInteractable.gameObject.SetActive(false);
        _currentExaminedObject = objectExaminer;
        _isExamining = false;
        _examineButton.SetActive(true);
    }

    public void PerformExamine()
    {
        Vector3 offsetScale;
        if (!_isExamining)
        {
            // Cache position, rotation and scale
            _cachedPosition = _currentExaminedObject.transform.position;
            _cachedRotation = _currentExaminedObject.transform.rotation;
            _cachedScale = _currentExaminedObject.transform.localScale;

            // Assign _currentExaminedObject position, rotation and scale
            _currentExaminedObject.transform.position = _examineTarget.transform.position;
            _currentExaminedObject.transform.parent = _examineTarget.transform;

            // Change scale of _currentExaminedObject to fit screen
            offsetScale = _cachedScale * _currentExaminedObject.GetComponent<ObjectExaminer>().examineScaleOffset;
            _currentExaminedObject.transform.localScale = offsetScale;

            _isExamining = true;

            _functionalityButton.SetActive(true);
        }
        else
        {
            /*
             * Return object to its original position, rotation and scale
            */
            _currentExaminedObject.transform.position = _cachedPosition;
            _currentExaminedObject.transform.rotation = _cachedRotation;
            _currentExaminedObject.transform.localScale = _cachedScale;
            _currentExaminedObject.transform.parent = null;

            _isExamining = false;

            _functionalityButton.SetActive(false);
        }
    }

    public void Functionality()
    {
        _currentExaminedObject.GetComponent<Functionality>().ToggleLights();
    }
}