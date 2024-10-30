using UnityEngine;

public class AcceleratedMovementBehaviour : MonoBehaviour
{
    private float _acceleration = 0;

    public float DeclerationSpeed = 0.5f;

    private void Update()
    {
        _acceleration = Mathf.Lerp(_acceleration, 0, DeclerationSpeed * Time.deltaTime);

        transform.ChangeXPosPerFrame(_acceleration);
    }

    public void AddToAccelerationPerFrame(float value)
    {
        _acceleration += value * Time.deltaTime;
    }

    public float GetAccleration()
    {
        return _acceleration;
    }

    public void SetAccleration(float value)
    {
        _acceleration = value;
    }
}
