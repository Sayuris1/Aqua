using UnityEngine;

[RequireComponent(typeof(AcceleratedMovementBehaviour))]
public class DrunkMovementBehaviour : MonoBehaviour
{
    // Speed
    public float DrunknessPower = 0.1f;

    // Sample Speed
    public float DirectionChangeTime = 0.1f;

    private float _noiseSampleLocation = 0;
    private float _timeSinceLastSample = 0;

    private AcceleratedMovementBehaviour _accelertedBehaviour;

    private void Start()
    {
        _accelertedBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    private void Update()
    {
        float random = SampleNoise(Time.deltaTime);
        float halfNegativeRandom = 0.5f - random;

        _accelertedBehaviour.AddToAccelerationPerFrame(halfNegativeRandom * DrunknessPower);
    }

    private float SampleNoise(float increaseLocation)
    {
        _timeSinceLastSample += Time.deltaTime;

        if(_timeSinceLastSample >= DirectionChangeTime)
        {
            _timeSinceLastSample = 0;

            _noiseSampleLocation += increaseLocation;
        }

        return Mathf.PerlinNoise1D(_noiseSampleLocation);
    }
}
