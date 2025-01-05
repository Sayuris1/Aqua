using UnityEngine;

[RequireComponent(typeof(AcceleratedMovementBehaviour))]
public class DrunkMovementBehaviour : MonoBehaviour
{
    // Speed
    public float DrunknessPower = 0.1f;
    public float DrunkSpeed = 1.0f;

    // Sample Speed
    public float DirectionChangeTime = 0.1f;

    private float _noiseSampleLocation = 0;
    private float _timeSinceLastSample = 0;

    private AcceleratedMovementBehaviour _accelertedBehaviour;

    private void Start()
    {
        _noiseSampleLocation = Time.time * Random.value;
        _accelertedBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    private void Update()
    {
        float random = SampleNoise(Time.deltaTime * DrunkSpeed);
        float halfNegativeRandom = random - 0.5f;

        Debug.Log(halfNegativeRandom * DrunknessPower);

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
