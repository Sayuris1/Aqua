using UnityEngine;

public class AcceleratedMovementBehaviour : MonoBehaviour
{
    public float Acceleration = 0;

    public float DeclerationSpeed = 0.5f;

    private void Update()
    {
        Acceleration = Mathf.Lerp(Acceleration, 0, DeclerationSpeed * Time.deltaTime);

        transform.ChangeXPosPerFrame(Acceleration);
    }

    public void AddToAccelerationPerFrame(float value)
    {
        Acceleration += value * Time.deltaTime;
    }

    public float GetAccleration()
    {
        return Acceleration;
    }

    public void SetAccleration(float value)
    {
        Acceleration = value;
    }
}
