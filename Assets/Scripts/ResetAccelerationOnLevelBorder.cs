using UnityEngine;

[RequireComponent(typeof(AcceleratedMovementBehaviour))]
public class ResetAccelerationOnLevelBorder : MonoBehaviour
{
    public float LevelXSize = 1;

    private AcceleratedMovementBehaviour _accelertedBehaviour;

    private void Start()
    {
        _accelertedBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    private void Update()
    {
        if(transform.position.x > LevelXSize && _accelertedBehaviour.GetAccleration() > 0 
            || transform.position.x < -LevelXSize && _accelertedBehaviour.GetAccleration() < 0)
            _accelertedBehaviour.SetAccleration(0);
    }
}
