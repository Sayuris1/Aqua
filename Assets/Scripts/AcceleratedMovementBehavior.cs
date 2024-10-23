using UnityEngine;

public class AcceleratedMovementBehaviour : MonoBehaviour
{
    private float _acceleration = 0;

    private void Update()
    {
        _acceleration = Mathf.Lerp(_acceleration, 0, 0.5f * Time.deltaTime);

        transform.ChangeXPosPerFrame(_acceleration);
    }

    public void AddToAccelerationPerFrame(float value)
    {
        _acceleration += value * Time.deltaTime;
    }
}
