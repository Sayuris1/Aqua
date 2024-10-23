using UnityEngine;
using UnityEngine.InputSystem;

public class SteerBehaviour : MonoBehaviour
{
    public float SteerSpeed = 1;

    private float _direction = 0;

    private void Update()
    {
        transform.ChangeXPosPerFrame(_direction * SteerSpeed);
    }

    public void GetSteerInput(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<float>();
    }
}
