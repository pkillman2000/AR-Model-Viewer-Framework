using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

/*
 * This is called by the 
 * AR Selection Interactable
 * Select event on each placeable object
*/
public class ObjectExaminer : MonoBehaviour
{
    /*
     * Set a new scale for ObjectExaminerManager 
     * so that object fits screen when examined
    */
    [SerializeField]
    public float examineScaleOffset = 1;

    private ObjectExaminerManager _objectExaminerManager;

    void Start()
    {
        _objectExaminerManager = FindObjectOfType<ObjectExaminerManager>();

        if(_objectExaminerManager == null )
        {
            Debug.LogError("Object Examiner Manager Not Found!");
        }

        _objectExaminerManager.ObjectPlaced(this.gameObject);
    }
}
