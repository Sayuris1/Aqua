using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AcceleratedMovementBehaviour))]
public class SteerBehaviour : MonoBehaviour
{
    public float SteerSpeed = 1;

    private float _direction = 0;
    private AcceleratedMovementBehaviour _accelertedBehaviour;

    private void Start()
    {
        _accelertedBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    private void Update()
    {
        _accelertedBehaviour.AddToAccelerationPerFrame(_direction * SteerSpeed);
    }

    public void GetSteerInput(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<float>();
    }
}
