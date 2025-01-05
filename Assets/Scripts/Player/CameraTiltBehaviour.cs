using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTiltBehaviour : MonoBehaviour
{
    public float Acc9;
    private AcceleratedMovementBehaviour _acceleratedMovementBehaviour;
    void Start()
    {
        _acceleratedMovementBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    void Update()
    {
        //transform.RotateAround(vector3(0, -1.128, 0), Vector3.up, _acceleratedMovementBehaviour.GetAccleration();
    }
}
